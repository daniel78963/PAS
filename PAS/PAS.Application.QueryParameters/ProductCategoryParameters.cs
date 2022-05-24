namespace PAS.Application.QueryParameters
{
    public class ProductCategoryParameters : QueryStringParameters
    {
        public ProductCategoryParameters()
        {
            OrderBy = "namecategory";
        }

        public string? NameCategory { get; set; }
    }
}
