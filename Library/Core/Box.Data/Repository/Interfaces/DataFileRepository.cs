using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface DataFileRepository
	{
        void Save(DataFile file);
        void Delete(DataFile file);
        List<DataFile> GetAll(int userId);
        DataFile? GetBySystemName(string systemName);
        DataFile? GetById(int id);
    }
}

