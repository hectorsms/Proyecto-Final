namespace WebAppBusMVC.WEB.Models
{
    public class UsersLoginResponseViewModel
    {
        public int IdUser { get; set; }
        public string? Usuario1 { get; set; }
        public string? Estado { get; set; }
        public virtual PersonalLoginResponseViewModel Personal { get; set; }
    }
}
