using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface UserRepository
	{
        User? GetByUsernamePassword(User user);
        bool CheckRepeatedUsername(string username);
        void Save(User user);
    }
}

