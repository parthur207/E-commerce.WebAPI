using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Domain.Enuns;
using Ecommerce.Domain.Models.AdminModels;
using Ecommerce.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        private readonly IProductInterface _productService;

        public ProductController(IProductInterface productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Response= await _productService.GetAllProducts();

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("search")]
        public async Task<IActionResult> GetProductById(string search)
        {
            var Response= await _productService.GetProductByName(search);

            if (Response.Item1 is false && Response.Item3 is null)
            {
                return BadRequest(Response.Item2);

            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("searchByCategory/{Category}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] ProductCategoryEnum Category)
        {
      
            var Response= await _productService.GetProductsByCategory(Category);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("price/{price}")]
        public async Task<IActionResult> GetProductsByPrice([FromRoute] decimal price)//Pegar todos os produtos de 0 a {price}
        {
          var Response = await _productService.GetProductsByPrice(price);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }


            return Ok(Response.Item3);
        }
    }
}
