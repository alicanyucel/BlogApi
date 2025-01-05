using BlogApi.Context;
using Microsoft.AspNetCore.Rewrite;

namespace BlogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();

            builder.Services.AddSqlServer<NewsletterDb>(builder.Configuration.GetConnectionString("SqlServer"));
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();
            // swagger üzerinden ayaða kaldýrma https://localhost:7272/index.html
      
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

      
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();

           
            app.MapControllers();

          
            app.Run();
        }
    }
}
