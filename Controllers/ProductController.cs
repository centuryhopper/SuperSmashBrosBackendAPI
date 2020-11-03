using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _productService;

        // dependency injection parameter
        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        #region GET AND POST METHODS

        // https://localhost:5001/api/Product
        [HttpGet]
        public ActionResult Get()
        {
            if (this._productService.IsEmpty())
            {
                return Ok("the list is empty");
            }
            return Ok(this._productService.GetProducts());
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            this._productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int idx)
        {
            this._productService.RemoveProduct(idx);
            return Ok();
        }
        #endregion

    }
}