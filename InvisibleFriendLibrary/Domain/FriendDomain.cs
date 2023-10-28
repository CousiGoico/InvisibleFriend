using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Domain{

    public class FriendDomain: IFriendDomain{

         private DataBaseRepository dataBaseRepository;

        public FriendDomain(DataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }

        public IList<Friend> Get()
        {
           var database = this.dataBaseRepository.Get();
            var friends = new List<Friend>();
            if (database != null && database.Friends != null){
                friends = database.Friends;
            }
            return friends; 
        }

        public void Post(Friend friend)
        {
           var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Friends == null){
                    database.Friends = new List<Friend>();
                }
                database.Friends.Add(friend);
                database.Save();
            }
        }

        public void Put(Friend friend)
        {
            var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Friends != null){
                    var currentFriend = database.Friends.FirstOrDefault(x => x.Id == friend.Id);
                    if (currentFriend != null){
                       currentFriend.Email = friend.Email;
                       currentFriend.Surname = friend.Surname;
                       currentFriend.Name = friend.Name;
                       currentFriend.CoupleId = friend.CoupleId;
                        database.Save();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Friends != null){
                    var currentFriend = database.Friends.FirstOrDefault(x => x.Id == id);
                    if (currentFriend != null){
                        database.Friends.Remove(currentFriend);
                        database.Save();
                    }
                }
            }
        }
    }
}