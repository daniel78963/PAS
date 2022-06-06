using PAS.Application.Attributes;

namespace PAS.Application.Dto
{
    public class ProductCategoryDto : BaseDto
    {
        [RequiredField(Validate = true, Message = "Field NameCategory is required", Code = "1402")]
        public string NameCategory { get; set; }
    }
}
