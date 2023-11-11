using System.ComponentModel.DataAnnotations.Schema;
using Autofac;
using InvisibleFriendAPI.Controllers;
using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Repositories;
using InvisibleFriendLibrary.Services;

namespace InvisibleFriendAPI;

public class Program
{
    private static IContainer? Container {get;set;}

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        Container = SetDependencyInjection();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseCors();
        

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

    private static IContainer SetDependencyInjection(){
        var builderAutofac = new ContainerBuilder();
        builderAutofac.RegisterModule<CoreLibModule>();
    
        builderAutofac.RegisterType<SmtpConfigurationController>().InstancePerRequest();
        builderAutofac.RegisterType<GameController>().InstancePerRequest();
        builderAutofac.RegisterType<FriendController>().InstancePerRequest();

        return builderAutofac.Build();
    }
}
