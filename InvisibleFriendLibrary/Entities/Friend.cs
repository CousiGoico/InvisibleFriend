
namespace InvisibleFriendLibrary;

[Serializable]
public class Friend : Item {

#region Properties
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CoupleId { get; set; }
#endregion


}