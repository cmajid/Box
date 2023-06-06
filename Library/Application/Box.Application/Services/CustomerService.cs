using Box.Contract.Interfaces.Services;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

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

        public void VerifyUser(User user)
        {
            var fetchedUser = repository.GetByUsernamePassword(user);
            if (fetchedUser == null)
                throw new UserNotFoundException(user.Username);
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
        public class UsernameRepeatedException : Exception
        {
            public UsernameRepeatedException() { }

            public UsernameRepeatedException(string name)
                : base(String.Format("Username is repeated: {0}", name)) { }
        }

        [Serializable]
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() { }

            public UserNotFoundException(string name)
                : base(String.Format("User not found: {0}", name)) { }
        }
    }
}