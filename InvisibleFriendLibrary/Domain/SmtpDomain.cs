using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Domain{

    public class SmtpDomain : ISmtpDomain
    {
        private DataBaseRepository dataBaseRepository;

        public SmtpDomain(DataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }

        public SmtpConfiguration Get()
        {
            var database = this.dataBaseRepository.Get();
            var smtpConfiguration = new SmtpConfiguration();
            if (database != null && database.SmtpConfiguration != null){
                smtpConfiguration = database.SmtpConfiguration;
            }
            return smtpConfiguration;  
        }

        public void Post(SmtpConfiguration smtpConfiguration)
        {
            var database = this.dataBaseRepository.Get();
            if (database != null && database.SmtpConfiguration != null){
                 database.SmtpConfiguration = smtpConfiguration;
                 database.Save();
            }
        }

        public void Put(SmtpConfiguration smtpConfiguration)
        {
            var database = this.dataBaseRepository.Get();
            if (database != null && database.SmtpConfiguration != null){
                 database.SmtpConfiguration.Port = smtpConfiguration.Port;
                 database.SmtpConfiguration.Password = smtpConfiguration.Password;
                 database.SmtpConfiguration.Ssl = smtpConfiguration.Ssl;
                 database.SmtpConfiguration.User = smtpConfiguration.User;
                 database.SmtpConfiguration.Smtp = smtpConfiguration.Smtp; 
                 database.Save();
            }
        }

        public void Delete()
        {
             var database = this.dataBaseRepository.Get();
            if (database != null){
                database.SmtpConfiguration = null;
                database.Save();
            }
        }
    }
}