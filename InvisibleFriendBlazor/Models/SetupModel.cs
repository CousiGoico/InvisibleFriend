namespace InvisibleFriendBlazor.Models{

    public class SetupModel {

        #region Properties

        public string Smtp { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool Ssl { get; set; }

        public int Port {get;set;}

        #endregion

    }
}