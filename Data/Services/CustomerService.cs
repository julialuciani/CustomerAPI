using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customerList = new List<Customer>(); 
        
        public virtual void Create(Customer customer)
        {
            _customerList.Add(customer);
           
        }

        public virtual IEnumerable<Customer> GetAll()
        {
            
            return _customerList;

        }

        public virtual Customer GetById(long id)
        {

           Customer customer = _customerList.FirstOrDefault(customer => customer.id == id);
            return customer;
        }

        public virtual void Update(Customer customer)
        {   
         var customerId = _customerList.FindIndex(element => element.id == customer.id);
            if (customerId == -1) throw new ArgumentNullException("Usuário não encontrado");

            _customerList[customerId] = customer;
                
           
        }

        public virtual void Delete(long id)
        {
            _customerList.RemoveAll(element => element.id == id);
            
           
        }
    }
}

 
