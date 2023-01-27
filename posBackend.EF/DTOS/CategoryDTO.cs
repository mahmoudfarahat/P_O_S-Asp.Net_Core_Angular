using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
