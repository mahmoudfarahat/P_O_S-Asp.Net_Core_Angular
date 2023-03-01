using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.DTOS
{
    class StoreDto
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
