using InvisibleFriendLibrary.Domain;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Services{

    public class FriendServices:IFriendService{

        private IFriendDomain friendDomain;

        public FriendServices(IFriendDomain friendDomain){
            this.friendDomain =friendDomain;
        }
    }

}