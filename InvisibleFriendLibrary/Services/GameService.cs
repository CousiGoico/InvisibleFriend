using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public class GameServices:IGameService{

        private IGameService gameDomain;

        public GameServices(IGameService gameDomain){
            this.gameDomain =gameDomain;
        }
    }

}