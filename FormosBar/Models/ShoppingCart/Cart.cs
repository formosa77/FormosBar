using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormosBar.Models.ShoppingCart
{
    [Serializable]
    public class Cart:IEnumerable<ItemsInCart>
    {
        public Cart() {
            this.itemsInCarts = new List<ItemsInCart>();
        }

        private List<ItemsInCart> itemsInCarts;

        public int Count {
            get {
                return this.itemsInCarts.Count;
            }
        }

        public int TotalAmount
        {
            get {
                int totalAmount = 0;
                foreach (var itemsInCart in this.itemsInCarts)
                {
                    totalAmount = totalAmount + itemsInCart.Total;
                }
                return totalAmount;
            }
        }

        public bool AddProduct(int ItemId)
        {
            var locateItem = this.itemsInCarts
                            .Where(s => s.Id == ItemId)
                            .Select(s => s)
                            .FirstOrDefault();

            if (locateItem == default(Models.ShoppingCart.ItemsInCart))
            {
                using (DAL.BarContext db = new DAL.BarContext())
                {
                    var stuff = (from s in db.Items
                                   where s.Id == ItemId
                                   select s).FirstOrDefault();
                    if (stuff != default(Models.Item))
                    {
                        this.AddProduct(stuff);
                    }
                }
            }
            else
            {   
                locateItem.Quantity += 1;
            }
            return true;
        }

        private bool AddProduct(Item item)
        {
            var stuff = new Models.ShoppingCart.ItemsInCart()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                DefaultImageURL = item.DefaultImageURL,
                ImgAlt = item.ImageAlt,
                Quantity = 1
            };

            this.itemsInCarts.Add(stuff);
            return true;
        }

        public bool RemoveProduct(int ItemId)
        {
            var locateItem = this.itemsInCarts
                            .Where(s => s.Id == ItemId)
                            .Select(s => s)
                            .FirstOrDefault();

            if (locateItem == default(Models.ShoppingCart.ItemsInCart))
            {
            }
            else { 
                this.itemsInCarts.Remove(locateItem);
            }
            return true;
        }

        public bool ClearCart() {
            this.itemsInCarts.Clear();
            return true;
        }

        public List<Models.OrderDetail> ToOrderDetailList(int orderId)
        {
            var result = new List<Models.OrderDetail>();
            foreach (var cartItem in this.itemsInCarts)
            {
                result.Add(new Models.OrderDetail()
                {
                    Name = cartItem.Name,
                    Price = cartItem.Price,
                    Quantity = cartItem.Quantity,
                    OrderId = orderId,
                    Status = 1
                });
            }
            return result;
        }

        #region IEnumerator

        IEnumerator<ItemsInCart> IEnumerable<ItemsInCart>.GetEnumerator()
        {
            return this.itemsInCarts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.itemsInCarts.GetEnumerator();
        }

        #endregion

    }
}

