using Big_Bang__Assessment_1.DB;
using Big_Bang__Assessment_1.Repository;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            try
            {
                var customers = await _customerRepository.GetCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while retrieving customers.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return customer;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while retrieving the customer.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var createdCustomer = await _customerRepository.CreateCustomer(customer);
                return CreatedAtAction(nameof(Get), new { id = createdCustomer.Customer_Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while creating the customer.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid || id != customer.Customer_Id)
                {
                    return BadRequest();
                }

                var updatedCustomer = await _customerRepository.UpdateCustomer(id, customer);
                if (updatedCustomer == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while updating the customer.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _customerRepository.DeleteCustomer(id);
                if (!isDeleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while deleting the customer.");
            }
        }
    }
}
