using Microsoft.AspNetCore.Mvc;
using PAS.Application.Interfaces;

namespace PAS.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;

        public CategoriesController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = productCategoryService.GetProductsCategories();
            return Ok(response);
        }
    }
}
