using workersView.Data;
using workersView.Interface;
using workersView.Repo;
using workersView.Auth;
using Microsoft.IdentityModel.Tokens;
using workersView.MiddleWare;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace workersView
{
    public partial class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                    
                });
            var services= builder.Services;
            services.AddCors();
            var workernewbase = new WorkerRepo(new DataRepo(builder.Configuration));
            services.AddSingleton(workernewbase);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(app => app.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("Error 500. Server Error");
                }));
                app.UseHttpsRedirection();
                
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); 
            options.DefaultFileNames.Add("Login.html"); 
            app.UseDefaultFiles(options); 
            app.UseStaticFiles();
            app.UseCors(builder=>builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.MapPost("/login", Login);
            app.MapPut("/update", Update);

            app.MapGet("/list",GetListofWork);
            app.MapGet("/listworkers", GetWorkers);
            app.MapGet("/get/{id}", GetWorker);
            app.MapGet("/status", WorkersStatus);
            app.MapGet("/date/{dateDo}/{datePosle}", SalaryPerDate);
            app.MapGet("/reportbyuniq/{uniq}", RezOfWorkByUniq);
            app.MapGet("/test", test);

            app.Run();
        }
       

    }
}