using AppServices.Services;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _customerAppService.Create(customer);
                return Created("Id: ", customer.Id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(long Id)
        {
            try
            {
                var customer = _customerAppService.GetById(Id);
                return Ok(customer);
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listCustomers = _customerAppService.GetAll();
                return Ok(listCustomers);
            }
            catch (Exception exception)
            {
                var exceptionMessage = exception.InnerException?.Message ?? exception.Message;
                return Problem(exceptionMessage);
            }
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _customerAppService.Update(customer);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long Id)
        {
            try
            {
                _customerAppService.Delete(Id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}