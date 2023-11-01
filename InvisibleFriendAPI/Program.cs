using System.ComponentModel.DataAnnotations.Schema;
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
        builder.Services.AddSingleton<ISmtpService>(new SmtpServices(new SmtpDomain(new DataBaseRepository())));
        builder.Services.AddSingleton<IFriendService>(new FriendServices(new FriendDomain(new DataBaseRepository())));
        builder.Services.AddSingleton<IGameService>(new GameServices(new GameDomain(new DataBaseRepository())));

        // Domain
        builder.Services.AddSingleton<ISmtpDomain>(new SmtpDomain(new DataBaseRepository()));
        builder.Services.AddSingleton<IFriendDomain>(new FriendDomain(new DataBaseRepository()));
        builder.Services.AddSingleton<IGameDomain>(new GameDomain(new DataBaseRepository()));
    

    }
}
