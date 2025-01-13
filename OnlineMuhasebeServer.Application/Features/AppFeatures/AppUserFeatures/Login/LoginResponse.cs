namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; set; }
        public string EMail { get; set; }
        public string UserId { get; set; }
        public string NameLastName { get; set; }
    }
}
