using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FormosBar.DAL;
using FormosBar.Models;

namespace FormosBar.Controllers.api
{
    public class OrdersController : ApiController
    {
        private BarContext db = new BarContext();

        // GET: api/Orders
        public IQueryable<OrderDto> GetOrders()
        {
            var orders = from b in db.Orders
                         select new OrderDto()
                         {
                             Id = b.Id,
                             OrderTableNumber = b.TableNumber,
                             OrderUserName = b.UserName,
                         };
            return orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderDetailDto))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            var order = await db.OrderDetails.Include(b => b.OrderId).Where(b => b.OrderId == id).Select(b =>
            new OrderDetailDto()
            {
                Id = b.Id,
                OrderId = b.OrderId,
                Name = b.Name,
                Quantity = b.Quantity,
                Price = b.Price,
                Status = b.Status
            }).ToListAsync();

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(OrderDto))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
}