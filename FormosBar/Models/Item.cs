using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormosBar.Models
{
    public class Item
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Category is required")]
        [DisplayName("Categorie")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 999, ErrorMessage = "Price must be between 1 and 999")]
        public int Price { get; set; }

        [Required(ErrorMessage = "On Shelf Status is required")]
        public bool OnShelf { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string DefaultImageURL { get; set; }

        [Required(ErrorMessage = "Image Alternative Text is required")]
        public string ImageAlt { get; set; }
    }

}