using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface DownloadRepository
    {
        void IncreaseDownload(Download download);
        int DownloadCount(int fileId);

    }
}

