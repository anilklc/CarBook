namespace CarBook.WebUI.Models
{
    public class JwtResponseModel
    {
        public string accessToken { get; set; }
        public int expiresIn { get; set; } // expiresIn alanının türünü string olarak değiştirildi
        public string refreshToken { get; set; }
    }

}
