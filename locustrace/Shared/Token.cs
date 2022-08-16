namespace locustrace.Shared
{
    //class for Token
    public class Token
    {
        //Token members
        public string access_token { get; set; }
        public long expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
