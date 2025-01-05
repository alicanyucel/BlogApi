namespace BlogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();

          
            builder.Services.AddSwaggerGen();

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
