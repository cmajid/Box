using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface UserRepository
	{
        bool CheckRepeatedUsername(string username);
        User? GetUserByUsername(string user);
        void Save(User user);
    }
}

