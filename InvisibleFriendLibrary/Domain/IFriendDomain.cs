using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Domain{

    public interface IFriendDomain {
        IList<Friend> Get();

        void Post(Friend friend);

        void Put(Friend friend);

        void Delete(int id);
    }
}