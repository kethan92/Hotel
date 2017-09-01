using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelManagement.Models.EntityModel;
using HotelManagement.ViewModel;

namespace HotelManagement.Controllers
{
    public class Room_TypeController : ApiController
    {
        private RoomManagerEntities db = new RoomManagerEntities();

        // GET: api/Room_Type
        public IQueryable<Room_Type> GetRoom_Type()
        {
            return db.Room_Type;
        }
        //search room_type and room
        [HttpGet]
        public IQueryable<List_Rooms> searchRoom_Type(string Room_Type)
        {
            var query = from a in db.Rooms
                        join b in db.Room_Status
                        on a.RoomStatus_id equals b.id_RoomStatus
                        join c in db.Room_Type
                        on a.RoomType_id equals c.room_Type_Code
                        where c.room_Type_Description==Room_Type                     
                        select new List_Rooms()
                        {
                            RoomNumber = a.RoomNumber,
                            nameRoom = a.nameRoom,
                            id_RoomStatus = b.id_RoomStatus,
                            room_Type_Code = c.room_Type_Code,
                            status = b.status,
                            room_Type_Description = c.room_Type_Description,
                            room_Standard_Rate = c.room_Standard_Rate
                        };

            return query;
        }
        // GET: api/Room_Type/5
        [ResponseType(typeof(Room_Type))]
        public IHttpActionResult GetRoom_Type(string id)
        {
            Room_Type room_Type = db.Room_Type.Find(id);
            if (room_Type == null)
            {
                return NotFound();
            }

            return Ok(room_Type);
        }

        // PUT: api/Room_Type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom_Type(string id, Room_Type room_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_Type.room_Type_Code)
            {
                return BadRequest();
            }

            db.Entry(room_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_TypeExists(id))
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

        // POST: api/Room_Type
        [ResponseType(typeof(Room_Type))]
        public IHttpActionResult PostRoom_Type(Room_Type room_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Room_Type.Add(room_Type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Room_TypeExists(room_Type.room_Type_Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = room_Type.room_Type_Code }, room_Type);
        }

        // DELETE: api/Room_Type/5
        [ResponseType(typeof(Room_Type))]
        public IHttpActionResult DeleteRoom_Type(string id)
        {
            Room_Type room_Type = db.Room_Type.Find(id);
            if (room_Type == null)
            {
                return NotFound();
            }

            db.Room_Type.Remove(room_Type);
            db.SaveChanges();

            return Ok(room_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Room_TypeExists(string id)
        {
            return db.Room_Type.Count(e => e.room_Type_Code == id) > 0;
        }
    }
}