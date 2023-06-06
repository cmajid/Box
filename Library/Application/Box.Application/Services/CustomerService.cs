using Box.Contract.Interfaces.Services;
using Box.Data.Repository.Interfaces;
using Box.Domain.Entities;

namespace Box.Application.Services
{
    public class CustomerService: UserService
    {
        private readonly UserRepository repository;
        public CustomerService(UserRepository repository)
        {
            this.repository = repository;
        }

        public void Save(User user)
        {
            repository.Save(user);
        }
    }
}