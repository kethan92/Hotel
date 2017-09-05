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
    public class RoomsController : ApiController
    {
        private RoomManagerEntities1 db = new RoomManagerEntities1();

        // GET: api/Rooms
       [HttpGet]
        public IQueryable<List_Rooms> GetAll()
        {
            /*
            var query = from a in db.Rooms
                        join b in db.Room_Status
                        on a.RoomType_id equals b.id_RoomStatus join c in db.Room_Type
                        on a.Room_Status equals c.room_Type_Code
                        select new List_Rooms()
                        {
                            RoomNumber = a.RoomNumber,
                            nameRoom = a.nameRoom,
                            id_RoomStatus = b.id_RoomStatus,
                            room_Type_Code=c.room_Type_Code,
                            status = b.status,
                            room_Type_Description = c.room_Type_Description,
                            room_Standard_Rate=c.room_Standard_Rate
                        };
            return query;
            */
            var model = from a in db.Rooms
                        from b in db.Room_Status
                        from c in db.Room_Type
                        where a.RoomStatus_id == b.id_RoomStatus && a.RoomType_id == c.room_Type_Code
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
            return model;
        }


        // GET: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(string id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomNumber)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rooms.Add(room);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(room.RoomNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = room.RoomNumber }, room);
        }

        // DELETE: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(string id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.Rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomExists(int id)
        {
            return db.Rooms.Count(e => e.RoomNumber == id) > 0;
        }
    }
}