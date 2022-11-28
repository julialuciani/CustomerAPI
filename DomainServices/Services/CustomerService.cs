using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customerList = new();

        public long Create(Customer customer)
        {
            var cpfAlreadyExists = _customerList.Any(customerElement => customerElement.Cpf == customer.Cpf);

            if (cpfAlreadyExists) throw new ArgumentException($"Customer for Cpf: {customer.Cpf} already exists!");

            var emailAlreadyExists = _customerList.Any(customerElement => customerElement.Email == customer.Email);

            if (emailAlreadyExists) throw new ArgumentException($"Customer for Email: {customer.Email} already exists!");
            
            customer.Id = _customerList.LastOrDefault()?.Id + 1 ?? 1;

            _customerList.Add(customer);

            return customer.Id;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer GetById(long Id)
        {
            var customer = _customerList.FirstOrDefault(customer => customer.Id == Id)
                ?? throw new ArgumentException($"Customer not found for Id: {Id}");

            return customer;
        }

        public void Update(Customer customer)
        {
            var customerIndex = _customerList.FindIndex(element => element.Id == customer.Id);

            if (customerIndex == -1) throw new ArgumentNullException($"Customer not found for Id: {customer.Id}");

            if (_customerList.Any((element) => element.Cpf == customer.Cpf && element.Id != customer.Id))
                throw new ArgumentException($"Customer for Cpf: {customer.Cpf} already exists!");

            if (_customerList.Any((element) => element.Email == customer.Email && element.Id != customer.Id))
                throw new ArgumentException($"Customer for Email: {customer.Email} already exists!");

            _customerList[customerIndex] = customer;
        }

        public void Delete(long Id)
        {
            var customer = GetById(Id);
            _customerList.Remove(customer);
        }
    }
}