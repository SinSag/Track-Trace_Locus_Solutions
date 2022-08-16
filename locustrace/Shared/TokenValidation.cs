namespace locustrace.Shared
{
    //class for TokenValidation
    public class TokenValidation
    {
        //TokenValidation members
        public string sub { get; set; }
        public string jti { get; set; }
        public string iat { get; set; }
        public string userInfo { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public string iss { get; set; }
        public string aud { get; set; }
    }
}
