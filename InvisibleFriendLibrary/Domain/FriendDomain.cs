using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Domain{

    public class FriendDomain{

         private DataBaseRepository dataBaseRepository;

        public FriendDomain(DataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }
    }
}