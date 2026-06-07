using Microsoft.EntityFrameworkCore;
using TestAsp.Data;

namespace TestAsp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=testdb.sqlite"));

            var app = builder.Build();

            // Автоматичне створення бази даних при запуску
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
            }

            app.UseStaticFiles(); // Щоб віддавати index.html
            app.UseAuthorization();
            app.MapControllers();
            
            // Якщо запит не до API, віддаємо UI
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}