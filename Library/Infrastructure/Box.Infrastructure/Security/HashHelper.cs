using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace Box.Infrastructure.Security
{
	public class HashHelper
	{

		public static string GetPasswordHash(string password)
		{
            var passwordHash
                = BCrypt.Net.BCrypt.HashPassword(password);
			return passwordHash;
        }

        public static bool GetPasswordHash(string password, string passwordHash)
        {
            var verify
                = BCrypt.Net.BCrypt.Verify(password,passwordHash);
            return verify;
        }

        public static string CreateToken(string key, string username)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username)};
            var credentials = CreateCredential(key);
            var jwt = CreateTokenWithCredential(claims, credentials);
            return jwt;
        }

        private static SigningCredentials CreateCredential(string key)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            return credentials;
        }

        private static string CreateTokenWithCredential(List<Claim> claims, SigningCredentials credentials)
        {
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

