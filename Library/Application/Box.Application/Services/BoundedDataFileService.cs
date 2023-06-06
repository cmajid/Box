using System;
using Box.Contract.Interfaces.Services;
using Box.Domain.Entities;
using Box.Repository.Interface;

namespace Box.Application.Services
{
    public class BoundedDataFileService : DataFileService
    {

        private readonly DataFileRepository repository;
        public BoundedDataFileService(DataFileRepository repository)
        {
            this.repository = repository;
        }

        public void Save(DataFile file)
        {
            repository.Save(file);
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Rename(DataFile file, string newName)
        {
            throw new NotImplementedException();
        }

    }
}

