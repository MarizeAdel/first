using CustomerModel;
using CustomerRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace CustomerProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public RCustomer Repo;
        public CustomerController() {
            Repo = new RCustomer();
        }
        
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                List<Customer> customers = Repo.GetAll();
                if (customers == null )
                {
                    return NotFound(); // Return 404 if no customers found
                }
                
                return Ok(customers);// Return 200 with customers
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 for invalid input
            }

            try
            {
                Repo.AddCustomer(customer.ID, customer.Name);
                return CreatedAtAction(nameof(Get), customer); // Return 201 with created customer
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        }
}
