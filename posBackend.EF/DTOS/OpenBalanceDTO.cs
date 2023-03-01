using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
    public class OpenBalanceDTO
    {
        public int ID { get; set; }
        public int storeId { get; set; }
        public DateTime OpenBalanceDate { get; set; }
        public string DocNumber { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public List<OpenBalanceDtDto> OpenBalancesDt { get; set; }

    }
}
