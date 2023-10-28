using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Domain{

    public interface ISmtpDomain{
        SmtpConfiguration Get();

        void Post(SmtpConfiguration smtpConfiguration);

        void Put(SmtpConfiguration smtpConfiguration);

        void Delete();
    }
}