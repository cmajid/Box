using System;
using Box.Domain.Args;
using Box.Domain.Entities;

namespace Box.Test.Domain
{
	public class UserDomainTest
	{
		private readonly User user;
		private readonly int userId;
		private readonly string username;
		private readonly string passwordHash;
		public UserDomainTest()
		{
			userId = 1;
			username = "username1";
			passwordHash = "XYZ";
			user = User.Create(new UserArgs(userId, username, passwordHash));
		}

		[Fact]
		public void AfterCreateUser_ShouldNotBeNull()
		{
			Assert.NotNull(user);
		}
	}
}

