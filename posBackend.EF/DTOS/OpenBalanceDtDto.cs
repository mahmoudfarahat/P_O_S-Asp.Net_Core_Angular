using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
   public class OpenBalanceDtDto
    {
        public int ID { get; set; }
        public int OpenBalanceId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalDt { get; private set; }
    }
}
