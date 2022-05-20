namespace PAS.Application.Dto
{
    public class ProductDto : IEntityDto        
    {
        public int Id { get ;  set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public ProductCategoryDto Categories { get; set; }

    }
}
