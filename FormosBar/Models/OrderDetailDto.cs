using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int Status { get; set; }
        public int Price { get; set; }
    }
}