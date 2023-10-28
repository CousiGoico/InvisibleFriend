using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Domain{

    public class GameDomain:IGameDomain
    {

        private DataBaseRepository dataBaseRepository;

        public GameDomain(DataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }
    }    

}