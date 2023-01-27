using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
   public class ProductDTO
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
        public List<ProductUnitsDTO> productUnits { get; set; }

        
    }

    public class ProductUnitsDTO
    {
       
        public int ProductID { get; set; } 
        public int UnitID { get; set; }
        public bool IsMainUnit { get; set; }
        public decimal ConvertFactor { get; set; }
        public int index { get; set; }
    }
}
