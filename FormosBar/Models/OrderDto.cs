using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderUserName { get; set; }
        public int OrderTableNumber { get; set; }
    }
}