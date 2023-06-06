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

        public void Save(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }
    }
}

