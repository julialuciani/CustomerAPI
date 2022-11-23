using DomainModels.Entities;
using DomainServices.Services;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private ICustomerService _customerService;

        public long Create(Customer customer)
        {
           return _customerService.Create(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
          return _customerService.GetAll();
        }

        public Customer GetById(long Id)
        {
          return _customerService.GetById(Id);
        }

        public void Update(Customer customer)
        {
            _customerService.Update(customer);
        }

        public void Delete(long Id)
        {
            _customerService.Delete(Id);
        }
    }
}