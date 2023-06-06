using System;
using Box.Data.EntityFramework;
using Box.Domain.Entities;
using Box.Repository.Interface;

namespace Box.Repository.EntityFramework
{
	public class EFDataFileRepository: DataFileRepository
    {
        private readonly ApplicationDbContext context;
        public EFDataFileRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Save(DataFile file)
        {
            context.DataFile.Add(file);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(DataFile file)
        {
            throw new NotImplementedException();
        }
    }
}

