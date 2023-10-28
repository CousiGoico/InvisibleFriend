using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendLibrary.Repositories;

[Serializable]
public class DataBaseRepository: IDataBaseRepository{

    #region Constants

    private const string pathToSaveFile = @"../InvisibleFriendLibrary/Data/data.json";

    #endregion

    #region Properties

    public List<Friend>? Friends {get;set;} = null;

    public List<Game>? Games {get;set;} = null;

    public SmtpConfiguration? SmtpConfiguration {get;set;} = null;

    #endregion

    #region Methods

    public DataBaseRepository? Get() {
        var json = Utils.ReadFromFile(pathToSaveFile);
        return Utils.ToType<DataBaseRepository>(json);
    }

    public void Save() {
        var json = Utils.ToJson<DataBaseRepository>(this);
        Utils.WriteInFile(pathToSaveFile, json);
    }

    #endregion

}