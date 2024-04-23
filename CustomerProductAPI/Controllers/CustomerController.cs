using CustomerModel;
using CustomerRepo;
using Microsoft.AspNetCore.Mvc;



namespace CustomerProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public RCustomer Repo=new RCustomer();
        
        [HttpGet(Name = "GetCustomers")]
        public ActionResult<RCustomer> Get()
        {
            try
            {
                var customers = Repo.GetAll();
                if (customers == null )
                {
                    return NotFound(); // Return 404 if no customers found
                }
                return Ok(customers.ToArray()); // Return 200 with customers
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost]
        public ActionResult<RCustomer> Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 for invalid input
            }

            try
            {
                Repo.AddCustomer(customer);
                return CreatedAtAction(nameof(Get), Repo); // Return 201 with created customer
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        }
}
