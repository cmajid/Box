using System;
using Box.Domain.Entities;

namespace Box.Contract.Interfaces.Services
{
	public interface UserService
	{
        void Register(User user);
        User VerifyUser(string username, string password);
    }
}

