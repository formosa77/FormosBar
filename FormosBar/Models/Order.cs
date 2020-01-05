using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int TableNumber { get; set; }
    }
}