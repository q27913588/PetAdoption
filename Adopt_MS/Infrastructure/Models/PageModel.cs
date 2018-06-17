using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt_MS.Infrastructure.Models
{
    public class PageModel
    {

        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Object Result { get; set; }
    }
}
