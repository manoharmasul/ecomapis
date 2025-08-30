using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowCores")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAsyncRepository productAsync;
        public ProductController(IProductAsyncRepository productAsync)
        {
            this.productAsync = productAsync;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel model)
        {
            var result=await productAsync.AddNewProduct(model);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductModel model)
        {
            var result=await productAsync.UpdateProduct(model);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result=await productAsync.DeleteProduct(id);
            return Ok(result);
        }
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result=await productAsync.GetProductById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(string? SearchText)
        {
            var result=await productAsync.GetProductducts(SearchText);
            return Ok(result);
        }
        [HttpGet("GetProductsList")]
        public async Task<IActionResult> GetProductsList(string? SearchText)
        {
            var result = await productAsync.GetProductlist(SearchText);
            return Ok(result);
        }
    }
}
