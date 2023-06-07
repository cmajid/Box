using System.Linq;
using Box.Data.EntityFramework;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(DataFile file)
        {
            throw new NotImplementedException();
        }

        public List<DataFile> GetAll(int userId)
        {
            return context.DataFile.Where(t => !t.IsDeleted && t.UserId == userId).ToList();
        }
    }
}

