using System;
using Box.Domain.Entities;

namespace Box.Data.Repository.Interfaces
{
	public interface DataFileRepository
	{
        void Save(DataFile file);
        void Delete(int id);
        void Update(DataFile file);
    }
}

