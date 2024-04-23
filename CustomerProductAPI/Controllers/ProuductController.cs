using Microsoft.AspNetCore.Mvc;
using ProductModel;
using ProductRepo;

namespace CustomerProductAPI.Controllers
{
    [ApiController]
     [Route("[controller]")]
    public class ProuductController: ControllerBase
    {
        public RProuduct PRepo = new RProuduct();

            [HttpGet(Name = "GetProuducts")]
            public ActionResult<RProuduct> Get()
            {
                try
                {
                    var products = PRepo.GetAll();
                    if (products == null )
                    {
                        return NotFound(); // Return 404 if no customers found
                    }
                    return Ok(products); // Return 200 with customers
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPost]
            public ActionResult<RProuduct> Post([FromBody] Product product)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Return 400 for invalid input
                }

                try
                {
                    PRepo.AddProduct(product);
                    return CreatedAtAction(nameof(Get), PRepo); // Return 201 with created customer
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }
}

