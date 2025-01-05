using BlogApi.Context;

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
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                   
                    c.RoutePrefix = string.Empty;  
                });
            }

      
            app.UseHttpsRedirection();
            app.UseAuthorization();

           
            app.MapControllers();

          
            app.Run();
        }
    }
}
