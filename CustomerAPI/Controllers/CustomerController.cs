using Data.Entities;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(Customer customer)
        {
            try
            {
                _service.Create(customer);
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
                var customer = _service.GetById(Id);
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
                var listCustomers = _service.GetAll();
                return Ok(listCustomers);
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _service.Update(customer);
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
                _service.Delete(Id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}