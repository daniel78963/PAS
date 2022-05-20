using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Application.Dto
{
    public class ProductCategoryDto : IEntityDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }

    }
}
