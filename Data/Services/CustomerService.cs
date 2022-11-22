using Data.Entities;

namespace Data.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customerList = new();

        public void Create(Customer customer)
        {
            var checkingCustomerCpf = _customerList.Any(customerElement => customerElement.Cpf == customer.Cpf);
            var checkingCustomerEmail = _customerList.Any(customerElement => customerElement.Email == customer.Email);
            if (checkingCustomerCpf == true) throw new ArgumentException($"Customer for Cpf: {customer.Cpf} already exists");
            if (checkingCustomerEmail == true) throw new ArgumentException($"Customer for Email: {customer.Email} already exists");

            customer.Id = _customerList.Count + 1;
            _customerList.Add(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            if (_customerList.Count == 0) throw new ArgumentException();
            return _customerList;
        }

        public Customer GetById(long Id)
        {
            var customer = _customerList.FirstOrDefault(customer => customer.Id == Id);
            if (customer != null) return customer;
            throw new ArgumentException($"Customer does not exist for Id: {Id}");
        }
        public void Update(Customer customer)
        {

            int customerIndex = _customerList.FindIndex(element => element.Id == customer.Id);

            if (customerIndex == -1) throw new ArgumentNullException($"Customer not found for Id: {customer.Id}");

            if (_customerList.Any((element) => element.Cpf == customer.Cpf && element.Id != customer.Id))
                throw new ArgumentException($"Customer for Cpf: {customer.Cpf} already exists!");

            if (_customerList.Any((element) => element.Email == customer.Email && element.Id != customer.Id))
                throw new ArgumentException($"Customer for Email: {customer.Email} already exists!");

            _customerList[customerIndex] = customer;

        }
        public void Delete(long Id)
        {
            var exists = _customerList.Any(customer => customer.Id == Id);
            if (!exists) throw new ArgumentNullException($"Customer not found for Id: {Id} ");
            _customerList.RemoveAll(element => element.Id == Id);
        }
    }
}


