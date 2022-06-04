using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Application.QueryParameters;

namespace PAS.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        //[HttpGet(Name = "Get")]
        //public IActionResult Get()
        //{
        //    var response = productCategoryService.GetProductsCategories();
        //    return Ok(response);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            //TODO: validations 
            //var dto = await productCategoryService.GetByIdAsync(id);
            //return Ok(dto);
            try
            {
                var response = await productCategoryService.GetByIdAsync(id);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Code = "500",
                    Message = "Error",
                    Result = ex.Message
                });
            }
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> AddAsync([FromBody] ProductCategoryDto dto)
        {
            if (dto == null)
            {
                return NotFound();
                //return BadRequest(e);
            }

            try
            {
                var response = await productCategoryService.AddAsync(dto);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Code = "500",
                    Message = "Error",
                    Result = ex.Message
                });
            }
        }

        [HttpGet(Name = "GetProductCategoryFilters")]
        public IActionResult GetProductCategoryFilters([FromQuery] ProductCategoryParameters parameters)
        {
            //TODO: REPOSITORY yendo a APLICATION QueryParameters
            var response = productCategoryService.GetProductsCategoriesFilters(parameters);
            return Ok(response);
        }
    }
}
