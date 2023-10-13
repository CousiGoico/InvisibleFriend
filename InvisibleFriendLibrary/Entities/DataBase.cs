namespace InvisibleFriendLibrary.Entities;

[Serializable]
public class DataBase{

    #region Constants

    private const string pathToSaveFile = @"../Data/data.json";

    #endregion

    #region Properties

    public List<Friend>? Friends {get;set;} = null;

    public List<Game>? Games {get;set;} = null;

    public SmtpConfiguration? Configuration {get;set;} = null;

    #endregion

    #region Methods

    public DataBase Get() {
        return new DataBase();        
    }

    public void Save() {
        var json = Utils.ToJson<DataBase>(this);
        Utils.WriteInFile(pathToSaveFile, json);
    }

    #endregion

}