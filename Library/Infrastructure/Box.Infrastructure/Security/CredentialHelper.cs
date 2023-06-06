using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Box.Infrastructure.Security
{
	public class CredentialHelper
	{
        public static SigningCredentials CreateCredential(string key)
        {
            var securityKey = GetSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            return credentials;
        }

        public static SymmetricSecurityKey GetSecurityKey(string key)
        {
            var result =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return result;
        }
    }
}

