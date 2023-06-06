using System;
using Box.Data.EntityFramework;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

namespace Box.Data.Repository.EFRepository
{
	public class EFUserRepository: UserRepository
    {
        private readonly ApplicationDbContext context;
        public EFUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User? GetByUsernamePassword(User user)
        {
            var fetchedUser = context.User.FirstOrDefault(t =>
                    t.Username == user.Username &&
                    t.PasswordHash == user.PasswordHash);

            return fetchedUser;
        }

        public void Save(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }

        public bool CheckRepeatedUsername(string username)
        {
            var repeated = context.User.Any(t => t.Username == username);
            return repeated;
        }
        
    }
}

