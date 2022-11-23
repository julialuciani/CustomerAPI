using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Services
{
    public interface ICustomerAppService
    {
        long Create(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
        void Update(Customer customer);
        void Delete(long id);
    }
}