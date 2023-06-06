namespace Box.Domain.Args
{
    public class UserArgs
    {
        public UserArgs(string username , string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}