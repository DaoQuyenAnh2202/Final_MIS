using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_MIS.Models
{
    public class Cart
    {
        public String productID { get; set; }
        public String productName { get; set; }
        public Decimal price { get; set; }
        public int quantity { get; set; }
        public Decimal money { get; set; }
    }
}