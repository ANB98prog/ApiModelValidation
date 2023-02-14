using Microsoft.AspNetCore.Mvc;
using static ModelValidation.Models.Models;

namespace ModelValidation.Controllers
{
    public record RegisterProductRequest(string SKU, string Name, string? Description);

    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterProductRequest request)
        {
            var (sku, name, description) = request;
            var productId = Guid.NewGuid();

            var registeredProduct = RegisterProduct.From(productId, sku, name, description);

            return Created($"/api/products/{productId}", productId);
        }
    }
}
