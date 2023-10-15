using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using workersView.Auth;

namespace workersView
{
    public partial class Program
    {
        private async static Task Login(HttpContext context)
        {
            var password = await context.Request.ReadFromJsonAsync<string>();
            await Console.Out.WriteLineAsync(password);
            if (password != "111")
            {
                context.Response.StatusCode = 400;
                return;
            }

            var jwt = new JwtSecurityToken(

                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            context.Response.WriteAsJsonAsync(encodedJwt);

        }
    }
}
