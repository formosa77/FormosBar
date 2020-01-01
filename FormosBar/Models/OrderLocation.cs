using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class OrderLocation
    {
        [Required(ErrorMessage = "Table is required")]
        [Display(Name = "Table Number")]
        [Range(1, 30, ErrorMessage = "Table Number must be between 1 and 30")]
        public int TableNumber{ get; set; }
        public int? OrderId { get; set; }
    }
}