using Box.Domain.Args;

namespace Box.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        private User(UserArgs args)
        {
            Username = args.Username;
            PasswordHash = args.PasswordHash;
        }

        public string Username { get; private set; }
        public string PasswordHash { get; private set; }

        public static User Create(UserArgs args)
        {
            return new User(args);
        }
    }
}