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
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        { 
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
                 return BadRequest();
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
