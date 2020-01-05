using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        // Foreign Key
        public int OrderId { get; set; }
        // Navigation property
        public Order Order { get; set; }
    }
}