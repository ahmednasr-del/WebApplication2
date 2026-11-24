using WebApplication2.CustomMiddleWare;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Add services for API App
            //builder.Services.AddControllers();

            builder.Services.AddMvc();

            var app = builder.Build();
            app.UseMiddleware<RequestTimingMiddleWare>();

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello");
            //    await next.Invoke(context);
            //    Console.WriteLine("Bye");
            //});


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            //app.MapControllerRoute(
            //    name:"shop",
            //    pattern:"shop/{id}",
            //    defaults: new
            //    {
            //        controller = "Product" ,
            //        action = "GetProductId"
            //    }
            //    );
            app.MapControllerRoute(
                name: "Default",
                pattern: "{controller}/{action}")
                .WithStaticAssets();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}")
            //    .WithStaticAssets();

            app.Run();
        }
    }
}
