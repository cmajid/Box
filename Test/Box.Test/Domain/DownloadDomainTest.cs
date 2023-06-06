using System;
using Box.Domain.Entities;

namespace Box.Test.Domain
{
	public class DownloadDomainTest
	{

		private readonly int fileId;
		private readonly Download download;
		public DownloadDomainTest()
		{
			fileId = 1;
			download = Download.Create(fileId);
		}

		[Fact]
		public void AfterDownloadAFile_ShouldNotBeNull()
		{
			Assert.NotNull(download);
		}

		[Fact]
		public void AfterDownloadAFile_ShouldHaveCreateDateTime()
		{
			Assert.NotEqual(DateTime.MinValue, download.CreateDateTime);
		}

		[Fact]
		public void AfterDownloadAFile_ShouldContainsFileId()
		{
			Assert.Equal(fileId, download.FileId);
		}
	}
}

