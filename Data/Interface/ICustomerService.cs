using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICustomerService
    {
        public void Create(Customer customer);

        public IEnumerable<Customer> GetAll();

        public Customer GetById(long id);
        public void Update(Customer customer);

        public void Delete(long id);  


    }
}
