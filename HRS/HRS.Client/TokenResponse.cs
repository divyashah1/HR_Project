namespace HRS.Client
{
    public class TokenResponse
    {
        public string? Token
        {
            get;
            set;
        }

        public string Message { get; set; }
        public string Error_Message { get; set; }

        public bool Status { get; set; }
    }
}
