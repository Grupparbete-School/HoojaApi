using HoojaApi.Data;
using Microsoft.EntityFrameworkCore;


namespace HoojaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add services to the container.
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            // builder.Services.AddDbContext<HoojaApiDbContext>(options =>
            //     options.UseSqlServer(connectionString));

            //loading the .env file
            DotNetEnv.Env.Load();

            // Retrieve the connection string from the environment variable
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'CONNECTION_STRING' not found.");
            }

            builder.Services.AddDbContext<HoojaApiDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers(); //behövs för att controller ska bli synliga
            builder.Services.AddControllersWithViews().AddNewtonsoftJson();

            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HoojaApiDbContext>();
                DummyData.DummyInsert(context);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // Add error handling middleware.
            app.UseExceptionHandler("/error");
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseAuthorization();

            app.UseRouting();


            app.MapControllers(); //viktig för att mappning ska fungera

  
            app.Run();
        }
    }
}