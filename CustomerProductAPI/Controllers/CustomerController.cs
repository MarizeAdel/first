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
        public static RCustomer Repo=new RCustomer();
        
        
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            try
            {
                var customers = Repo.GetAll();
                
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
        public  ActionResult  Post([FromBody] Customer customer)
        {
            try
            {
                Repo.AddCustomer(new Customer (customer.ID,customer.Name));

                return CreatedAtAction(nameof(Get), Repo.GetAll()); // Return 201 with created customer
                
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        }
}
