using Box.Contract.Interfaces.Services;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;
using Box.Infrastructure.Security;

namespace Box.Application.Services
{
    public class CustomerService: UserService
    {
        private readonly UserRepository repository;
        public CustomerService(UserRepository repository)
        {
            this.repository = repository;
        }

        public void Register(User user)
        {
            checkRepeatedUsername(user.Username);
            repository.Save(user);
        }

        public User VerifyUser(string username, string password)
        {
            var user = GetUserByUsername(username);
            if (user == null)
                throw new UsernameOrPasswordNotFoundException(username);

            VerifyPassword(username, password, user);
            return user;
        }

        private static void VerifyPassword(string username, string password, User user)
        {
            var verifyPassword = HashHelper.VerfiyPassword(password, user.PasswordHash);
            if (!verifyPassword)
                throw new UsernameOrPasswordNotFoundException(username);
        }

        private User GetUserByUsername(string username)
        {
            var user = repository.GetUserByUsername(username);
            if (user == null)
                throw new UsernameOrPasswordNotFoundException(username);
            return user;
        }

        private void checkRepeatedUsername(string username)
        {
            var usernameIsRepeated = repository.CheckRepeatedUsername(username);
            if (usernameIsRepeated)
            {
                throw new UsernameRepeatedException(username);
            }
        }

        [Serializable]
        public class UsernameRepeatedException : ApplicationException
        {
            public UsernameRepeatedException() { }

            public UsernameRepeatedException(string name)
                : base(String.Format("Username is repeated: {0}", name)) { }
        }

        [Serializable]
        public class UserNotFoundException : ApplicationException
        {
            public UserNotFoundException() { }

            public UserNotFoundException(string name)
                : base(String.Format("User not found: {0}", name)) { }
        }

        [Serializable]
        public class UsernameOrPasswordNotFoundException : ApplicationException
        {
            public UsernameOrPasswordNotFoundException() { }

            public UsernameOrPasswordNotFoundException(string name)
                : base(String.Format("Username or Password not found: {0}", name)) { }
        }
    }
}