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
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:58360") 
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();
            // swagger üzerinden ayaða kaldýrma https://localhost:7272/index.html
      
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
           
            app.UseAuthorization();

           
            app.MapControllers();

          
            app.Run();
        }
    }
}
