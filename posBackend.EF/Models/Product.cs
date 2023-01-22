using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal PurchaseingPrice { get; set; }
        public decimal WholesaleSellingPrice { get; set; }
        public decimal SectoralSellingPrice { get; set; }
        public decimal HalfSectoralSellingPrice { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; set; }

        public Category Category { get; set; }
        public ICollection<Unit> Units { get; set; }
        public List<ProductUnit> ProductUnits { get; set; }
    }
}
