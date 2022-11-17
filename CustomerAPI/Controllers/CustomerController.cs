using Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;

namespace CustomerAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;
       

        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            

        }

        [HttpPost]
        public void Create(Customer customer)
        {
            _service.Create(customer);

        }

        [HttpGet("{id}")]

        public Customer GetById(long id)
        {

            return _service.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPut]
        public void Update(Customer customer)
        {
            _service.Update(customer);  

        }

        [HttpDelete]

        public void Delete(long id)
        {
            _service.Delete(id);
        }

    


    }
}




