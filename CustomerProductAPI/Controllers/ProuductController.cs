using Microsoft.AspNetCore.Mvc;
using ProductModel;
using ProductRepo;

namespace CustomerProductAPI.Controllers
{
    [ApiController]
     [Route("[controller]")]
    public class ProuductController: ControllerBase
    {
        public static RProduct PRepo = new RProduct();

            [HttpGet(Name = "GetProuducts")]
            public ActionResult<Product> Get()
            {
                try
                {
                    var products = PRepo.GetAll();
                    if (products == null )
                    {
                        return NotFound(); // Return 404 if no prouduc found
                    }
                    return Ok(products); // Return 200 with customers
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPost]
            public ActionResult<Product> Post([FromBody] Product product)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return 400 for invalid input
                }

                try
                {
                    PRepo.AddProduct(product);
                    return CreatedAtAction(nameof(Get), product); // Return 201 with created customer
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
}

