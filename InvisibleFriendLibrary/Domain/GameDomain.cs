using System.Reflection.Metadata.Ecma335;
using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Domain{

    public class GameDomain : IGameDomain
    {

        private DataBaseRepository dataBaseRepository;

        public GameDomain(DataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }

        public IList<Game> Get(){
            var database = this.dataBaseRepository.Get();
            var games = new List<Game>();
            if (database != null && database.Games != null){
                games = database.Games;
            }
            return games;           
        }

        public void Post(Game game) {
            var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Games == null){
                    database.Games = new List<Game>();
                }
                database.Games.Add(game);
                database.Save();
            }
        }

        public void Put(Game game) {
            var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Games != null){
                    var currentGame = database.Games.FirstOrDefault(x => x.Id == game.Id);
                    if (currentGame != null){
                        currentGame.Friends = game.Friends;
                        currentGame.DateGivePresent = game.DateGivePresent;
                        currentGame.StartDate = game.StartDate;
                        currentGame.Budget = game.Budget;
                        currentGame.Name = game.Name;
                        currentGame.Location = game.Location;
                        database.Save();
                    }
                }
            }
        }

        public void Delete(int id){
             var database = this.dataBaseRepository.Get();
            if (database != null){
                if (database.Games != null){
                    var currentGame = database.Games.FirstOrDefault(x => x.Id == id);
                    if (currentGame != null){
                        database.Games.Remove(currentGame);
                        database.Save();
                    }
                }
            }
        }
    }    

}