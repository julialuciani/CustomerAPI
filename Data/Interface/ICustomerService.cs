using Data.Entities;
using System.Collections.Generic;

namespace Data.Services
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
        void Update(Customer customer);
        void Delete(long id);
    }
}