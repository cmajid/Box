using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface UserRepository
	{
        void Save(User user);
    }
}

