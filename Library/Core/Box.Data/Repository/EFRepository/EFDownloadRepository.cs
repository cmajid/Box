using System;
using Box.Data.EntityFramework;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

namespace Box.Data.Repository.EFRepository
{
	public class EFDownloadRepository: DownloadRepository
    {
        private readonly ApplicationDbContext context;
        public EFDownloadRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int DownloadCount(int fileId)
        {
            var count = context.Download.Count(t => t.FileId == fileId);
            return count;
        }

        public void IncreaseDownload(Download download)
        {
            context.Download.Add(download);
            context.SaveChanges();
        }
    }
}

