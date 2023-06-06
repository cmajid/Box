using System;
namespace Box.Infrastructure.Security
{
	public class HashHelper
	{

		public static string GetPasswordHash(string password)
		{
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(password);

			return passwordHash;
        }
	}
}

