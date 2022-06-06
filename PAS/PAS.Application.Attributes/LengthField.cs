using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Application.Attributes
{
    public class LengthField :  CustomAttribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
