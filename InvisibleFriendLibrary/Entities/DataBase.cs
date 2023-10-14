namespace InvisibleFriendLibrary.Entities;

[Serializable]
public class DataBase{

    #region Constants

    private const string pathToSaveFile = @"../InvisibleFriendLibrary/Data/data.json";

    #endregion

    #region Properties

    public List<Friend>? Friends {get;set;} = null;

    public List<Game>? Games {get;set;} = null;

    public SmtpConfiguration? SmtpConfiguration {get;set;} = null;

    #endregion

    #region Methods

    public static DataBase? Get() {
        var json = Utils.ReadFromFile(pathToSaveFile);
        return Utils.ToType<DataBase>(json);
    }

    public void Save() {
        var json = Utils.ToJson<DataBase>(this);
        Utils.WriteInFile(pathToSaveFile, json);
    }

    #endregion

}