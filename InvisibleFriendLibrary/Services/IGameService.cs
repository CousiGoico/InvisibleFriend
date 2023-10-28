using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public interface IGameService{

        IList<Game> Get();

        void Post(Game game);

        void Put(Game game);

        void Delete(int id);
    }

}