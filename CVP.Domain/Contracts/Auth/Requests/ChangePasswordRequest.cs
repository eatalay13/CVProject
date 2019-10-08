namespace CVP.Domain.Contracts.Auth.Requests
{
    public class ChangePasswordRequest : RequestBase
    {
        public  string EmailAddress { get; set; }
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}
