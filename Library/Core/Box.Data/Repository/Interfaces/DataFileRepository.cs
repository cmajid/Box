using System;
using Box.Domain.Entities;

namespace Box.Repository.Interface
{
	public interface DataFileRepository
	{
        void Save(DataFile file);
        void Delete(int id);
        void Update(DataFile file);
    }
}

