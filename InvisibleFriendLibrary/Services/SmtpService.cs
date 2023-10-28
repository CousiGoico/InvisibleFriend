using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public class SmtpServices:ISmtpService{

        private ISmtpDomain smtpDomain;

        public SmtpServices(ISmtpDomain smtpDomain){
            this.smtpDomain = smtpDomain;
        }     

        public SmtpConfiguration Get()
        {
            return this.smtpDomain.Get();
        }

        public void Post(SmtpConfiguration smtpConfiguration)
        {
            this.smtpDomain.Post(smtpConfiguration);
        }

        public void Put(SmtpConfiguration smtpConfiguration)
        {
            this.smtpDomain.Put(smtpConfiguration);
        }

         public void Delete()
        {
            this.smtpDomain.Delete();
        }
    }

}