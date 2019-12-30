using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}