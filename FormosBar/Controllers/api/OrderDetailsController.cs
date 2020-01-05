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
    public class OrderDetailsController : ApiController
    {
        private BarContext db = new BarContext();

        // GET: api/OrderDetails
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            //var orderdetails = from b in db.OrderDetails
            //                   select new OrderDetailDto() {
            //                       Id = b.OrderId,
            //                       Name = b.Name,
            //                       Quantity = b.Quantity
            //                   };
            return db.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [ResponseType(typeof(OrderDetailDto))]
        public async Task<IHttpActionResult> GetOrderDetail(int id)
        {
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
            //var orderdetail = await db.Orders.Include(b => b.Id).Select(b =>
            //new OrderDto()
            //{
            //    Id = b.Id,

            //}).SingleOrDefaultAsync(b => b.Id == id);

            //if (orderdetail == null)
            //{
            //    return NotFound();
            //}

            //return Ok(orderdetail);
        }

        // PUT: api/OrderDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails
        [ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> PostOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderDetails.Add(orderDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderDetail.Id }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            db.OrderDetails.Remove(orderDetail);
            await db.SaveChangesAsync();

            return Ok(orderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDetailExists(int id)
        {
            return db.OrderDetails.Count(e => e.Id == id) > 0;
        }
    }
}