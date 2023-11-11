using Autofac;
using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Services;

public class CoreLibModule: Autofac.Module{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<FriendDomain>().As<IFriendDomain>().SingleInstance();
        builder.RegisterType<GameDomain>().As<IGameDomain>().SingleInstance();
        builder.RegisterType<SmtpDomain>().As<ISmtpDomain>().SingleInstance();

        builder.RegisterType<FriendServices>().As<IFriendService>().SingleInstance();
        builder.RegisterType<GameServices>().As<IGameService>().SingleInstance();
        builder.RegisterType<SmtpServices>().As<ISmtpService>().SingleInstance();
    }

}