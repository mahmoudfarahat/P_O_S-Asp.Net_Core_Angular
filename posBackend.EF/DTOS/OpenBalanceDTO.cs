using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
    public class OpenBalanceDTO
    {
        public int ID { get; set; }
        [Required]
        public int storeId { get; set; }
        [Required]

        public DateTime OpenBalanceDate { get; set; }
        [Required]

        public string DocNumber { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public List<OpenBalanceDtDto> OpenBalancesDt { get; set; }

    }
}
