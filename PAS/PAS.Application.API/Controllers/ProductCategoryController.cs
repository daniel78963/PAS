using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Application.QueryParameters;
using Swashbuckle.AspNetCore.Annotations;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
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

        [HttpPut(Name = "Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await productCategoryService.UpdateAsync(dto);
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

        [HttpDelete]
        [SwaggerOperation("Delete ProductCategory")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400)]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<IActionResult> DeleteAsync([FromBody] ProductCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Null object in request");
            }

            try
            {
                var response = await productCategoryService.DeleteAsync(dto);
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
