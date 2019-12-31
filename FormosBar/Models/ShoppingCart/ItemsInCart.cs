using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models.ShoppingCart
{
    [Serializable]
    public class ItemsInCart
    {
       public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Total
        { 
            get
            {
                return this.Price * this.Quantity;
            }
        }

        public string DefaultImageURL { get; set; }

        public string ImgAlt { get; set; }

    }
}