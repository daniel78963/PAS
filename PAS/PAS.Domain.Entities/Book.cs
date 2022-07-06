using System.ComponentModel.DataAnnotations;

namespace PAS.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 250)]
        public string Title { get; set; }

    }
}
