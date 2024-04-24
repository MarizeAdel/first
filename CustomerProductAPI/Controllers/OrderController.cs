using CustomerModel;
using Microsoft.AspNetCore.Mvc;
using OrderModel;
using ProductModel;

namespace CustomerProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        Order order=new Order();
        [HttpGet]
        public ActionResult<Product[]> Get()
        {
            try
            {
                var o1 = order.products;
                if(o1 == null)
                {
                    return NotFound(); // Return 404 
                }
                return Ok(o1);// Return 200 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Product p1)
        {
            try
            {
                if(p1 == null)
                {
                    return NotFound(); // Return 404 

                }
                order.AddProuduct(p1);
                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

    }
}
