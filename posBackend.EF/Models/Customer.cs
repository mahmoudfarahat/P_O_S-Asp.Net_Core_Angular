using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public decimal Limit { get; set; }
        public decimal FirstBalance { get; set; }
        public string RegisterNumber { get; set; }
        public string CustomerEmail { get; set; }
        public byte[] Image { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsMixed { get; set; }
        public bool IsActive { get; set; }
    }
}
