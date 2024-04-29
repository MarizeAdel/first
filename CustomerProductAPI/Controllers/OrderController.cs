using CustomerModel;
using Microsoft.AspNetCore.Mvc;
using OrderModel;
using ProductModel;
using ROrder;

namespace CustomerProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public static OrderRepo Repo;
        [HttpGet]
        public ActionResult<Product[]> Get()
        {
            try
            {
                var o1 = Repo.order.GetAll();
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
                if (p1 == null)
                {
                    return NotFound(); // Return 404 

                }
                Repo.order.AddProuduct(p1);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

        [HttpPost("create")]

        public ActionResult Post([FromBody] Customer c1)
            {
                try
                {
                    Repo= new OrderRepo(c1);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");

                }

            }

        }
}
