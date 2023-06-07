using System.Linq;
using Box.Data.EntityFramework;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Box.Data.Repository.EFRepository
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

        public void Delete(DataFile file)
        {
            file.Delete();
            context.Entry(file).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Share(DataFile file, int timeInMinutes)
        {
            file.Share(DateTime.Now.AddMinutes(timeInMinutes));
            context.Entry(file).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<DataFile> GetAll(int userId)
        {
            var result = context.DataFile
                .Where(t => !t.IsDeleted && t.UserId == userId)
                .ToList();

            return result;
        }

        public DataFile? GetBySystemName(string systemName)
        {
            return context.DataFile.Where(t => !t.IsDeleted && t.SystemName == systemName).FirstOrDefault();

        }

        public DataFile? GetById(int id)
        {
            return context.DataFile.Where(t => !t.IsDeleted && t.Id == id).FirstOrDefault();
        }

        
    }
}

