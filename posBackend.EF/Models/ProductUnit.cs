using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class ProductUnit
    {
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public bool IsMainUnit { get; set; }
        public decimal ConvertFactor { get; set; }
        public int index { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        
    }
}
