using System;
using Box.Contract.DTOs;
using Box.Domain.Entities;

namespace Box.Contract.Interfaces.Services
{
	public interface DataFileService
	{
        void Save(DataFile file);
        void Delete(int id);
        void Rename(DataFile file, string newName);
        List<DataFileDTO> GetAll(int userId);
        DataFile DownloadFile(string username, string systemName);
    }
}

