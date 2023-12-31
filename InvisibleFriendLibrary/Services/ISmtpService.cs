using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public interface ISmtpService{
        
        SmtpConfiguration Get();

        void Post(SmtpConfiguration smtpConfiguration);

        void Put(SmtpConfiguration smtpConfiguration);

        void Delete();
    }

}