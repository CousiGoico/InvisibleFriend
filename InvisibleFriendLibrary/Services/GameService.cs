using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public class GameServices:IGameService{

        private IGameService gameDomain;

        public GameServices(IGameService gameDomain){
            this.gameDomain =gameDomain;
        }

        public IList<Game> Get(){
            return this.gameDomain.Get();
        }

        public void Post(Game game) {
            this.gameDomain.Post(game);
        }

        public void Put(Game game){
            this.gameDomain.Put(game);
        }

        public void Delete(int id){
            this.gameDomain.Delete(id);
        }
    }

}