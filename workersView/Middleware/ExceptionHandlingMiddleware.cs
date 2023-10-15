namespace workersView.MiddleWare
{
    public class ExceptionHandlingMiddleware
    {
        

        private  RequestDelegate next {  get; set; }
        private  ILogger<ExceptionHandlingMiddleware> logger {  get; set; }

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<div style=\"text-align: center;\"><h1>Error 500. Server Error</h1></div>");
            }

        }



    }
}
