namespace Box.Domain.Args
{
    public class UserArgs
    {
        public UserArgs(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        public UserArgs(string username , string passwordHash, int id)
        {
            Username = username;
            PasswordHash = passwordHash;
            Id = id;
        }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int? Id { get; set; }
    }
}