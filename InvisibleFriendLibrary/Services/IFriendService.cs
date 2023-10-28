using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public interface IFriendService{
        IList<Friend> Get();

        void Post(Friend friend);

        void Put(Friend friend);

        void Delete(int id);
    }

}