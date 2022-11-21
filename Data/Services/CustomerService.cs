using Data.Entities;
using Data.Utilities;
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
            var checkingCustomerCpf = _customerList.FirstOrDefault(customerElement => customerElement.Cpf == customer.Cpf);
            var checkingCustomerEmail = _customerList.FirstOrDefault(customerElement => customerElement.Email == customer.Email);
            if (checkingCustomerCpf != null || checkingCustomerEmail != null) throw new ArgumentNullException("Customer already exists");

            customer.Id = _customerList.Count + 1;
            _customerList.Add(customer);
        }

        public virtual IEnumerable<Customer> GetAll()
        {
            return _customerList;
        }

        public virtual Customer GetById(long Id)
        {
            var customer = _customerList.FirstOrDefault(customer => customer.Id == Id);
            if (customer != null) return customer;
            throw new ArgumentException("Customer doesn't exist!");
        }
        public virtual void Update(Customer customer)
        {
            var customerInList = _customerList.FirstOrDefault(element => element.Id == customer.Id);

            int customerIndex = _customerList.FindIndex(element => element.Id == customer.Id);

            if (customerIndex == -1) throw new ArgumentNullException("Customer not found with Id: " + customer.Id);

            if (_customerList.Any((element) => element.Cpf == customer.Cpf && element.Id != customer.Id))
                throw new ArgumentException("Customer can't have Cpf equal to other customer!");

            if (_customerList.Any((element) => element.Email == customer.Email && element.Id != customer.Id))
                throw new ArgumentException("Customer can't have Email equal to other customer!");

            _customerList[customerIndex] = customer;

        }
        public virtual void Delete(long Id)
        {
            int customerId = _customerList.FindIndex(element => element.Id == Id);
            if (customerId < 0) throw new ArgumentNullException("Customer not found with Id: " + Id);
            _customerList.RemoveAll(element => element.Id == Id);
        }
    }
}


