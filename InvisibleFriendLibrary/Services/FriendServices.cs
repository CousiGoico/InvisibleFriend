using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public class FriendServices:IFriendService{

        private IFriendDomain friendDomain;

        public FriendServices(IFriendDomain friendDomain){
            this.friendDomain =friendDomain;
        }

        public IList<Friend> Get()
        {
            return this.friendDomain.Get();
        }

        public void Post(Friend friend)
        {
            this.friendDomain.Post(friend);
        }

        public void Put(Friend friend)
        {
            this.friendDomain.Put(friend);
        }

        public void Delete(int id)
        {
            this.friendDomain.Delete(id);
        }
    }

}