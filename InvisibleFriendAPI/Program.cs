using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Repositories;
using InvisibleFriendLibrary.Services;

namespace InvisibleFriendAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        SetDependencyInjection(builder);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    private static void SetDependencyInjection(WebApplicationBuilder builder){
        // Repositories
        builder.Services.AddSingleton<IDataBaseRepository, DataBaseRepository>();
        
        // // Services
        // builder.Services.AddScoped<ISmtpService, SmtpServices>();
        // builder.Services.AddScoped<IFriendService, FriendServices>();
        // builder.Services.AddScoped<IGameService, GameServices>();

        // // Domain
        // builder.Services.AddScoped<ISmtpDomain, SmtpDomain>();
        // builder.Services.AddScoped<IFriendDomain, FriendDomain>();
        // builder.Services.AddScoped<IGameDomain, GameDomain>();
    

    }
}
