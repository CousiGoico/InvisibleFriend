using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Domain{

    public interface IGameDomain{
        IList<Game> Get();
        
        void Post(Game game);

        void Put(Game game);

        void Delete(int id);
    }
}