using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class Unit
    {
        public int ID { get; set; }
        public string UnitName { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<ProductUnit> ProductUnits { get; set; }
    }
}
