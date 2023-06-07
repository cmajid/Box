using Box.Contract.DTOs;
using Box.Contract.Interfaces.Services;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

namespace Box.Application.Services
{
    public class BoundedDataFileService : DataFileService
    {
        private readonly DataFileRepository repository;
        public BoundedDataFileService(DataFileRepository repository)
        {
            this.repository = repository;
        }

        public void Save(Domain.Entities.DataFile file)
        {
            repository.Save(file);
        }
        public void Delete(int id)
        {
            var file = repository.GetById(id);
            if (file == null)
                throw new DataFile.FileNotFoundExtentionException(id.ToString());

            repository.Delete(file);
        }

        public void Rename(Domain.Entities.DataFile file, string newName)
        {
            throw new NotImplementedException();
        }

        public List<DataFileDTO> GetAll(int userId)
        {
            var result =  repository.GetAll(userId);
            var dtos = Convert(result);
            return dtos;
        }

        public DataFile DownloadFile(string username, string systemName)
        {
            var file = repository.GetBySystemName(systemName);
            if (file == null)
                throw new DataFile.FileNotFoundExtentionException(systemName);

            if(file.UserName != username)
                throw new DataFile.FileNotFoundExtentionException(systemName);

            return file;
        }

        private List<DataFileDTO> Convert(List<DataFile> files)
        {
            var list = new List<DataFileDTO>();
            foreach(var item in files)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        private DataFileDTO Convert(DataFile file)
        {
            var result = new DataFileDTO
            {
                Id = file.Id,
                CreatedDatetime = file.CreatedDatetime,
                Extention = file.Extention,
                Name = file.Name,
                PublicDownloadDateTime = file.PublicDownloadDateTime,
                Size = file.Size,
                SystemName = file.SystemName,
                UpdatedDateTime = file.UpdatedDateTime,
                Url = file.Url,
                Username = file.UserName,
            };

            return result;
        }
    }
}