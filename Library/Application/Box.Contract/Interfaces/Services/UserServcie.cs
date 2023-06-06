using System;
using Box.Domain.Entities;

namespace Box.Contract.Interfaces.Services
{
	public interface UserService
	{
        void Save(User file);
    }
}

