namespace PAS.Application.Dto.Account
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
