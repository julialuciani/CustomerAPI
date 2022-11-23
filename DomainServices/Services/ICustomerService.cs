using DomainModels.Entities;

namespace DomainServices.Services
{
    public interface ICustomerService
    {
        long Create(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
        void Update(Customer customer);
        void Delete(long id);
    }
}