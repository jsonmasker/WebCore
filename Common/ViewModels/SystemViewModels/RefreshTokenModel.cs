namespace Common.ViewModels.SystemViewModels
{
    public class RefreshTokenModel
    {
        //public string UserID { get; set; }
        public string KeyRefresh { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; private set; }
        public bool IsUsed { get; set; }
        public RefreshTokenModel()
        {
            KeyRefresh = string.Empty;
            Token = string.Empty;
            CreatedOn = DateTime.Now;
            IsUsed = false;
        }
    }
}
