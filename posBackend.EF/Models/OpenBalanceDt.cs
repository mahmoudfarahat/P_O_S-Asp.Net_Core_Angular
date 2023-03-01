using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class OpenBalanceDt
    {
        public int ID { get; set; }
        public int OpenBalanceId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalDt { get; private set; }

        public OpenBalance OpenBalance { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
    }
}
