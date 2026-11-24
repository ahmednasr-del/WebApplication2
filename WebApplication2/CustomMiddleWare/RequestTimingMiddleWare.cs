using System.Diagnostics;

namespace WebApplication2.CustomMiddleWare
{
    public class RequestTimingMiddleWare
    {
        private readonly RequestDelegate next;

        public RequestTimingMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await next.Invoke(context);  
            watch.Stop();
            Console.WriteLine($"{context.Request.Path}   {watch.ElapsedMilliseconds} ms");
        }
    }
}
