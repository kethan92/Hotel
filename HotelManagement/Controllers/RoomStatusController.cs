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

namespace HotelManagement.Controllers
{
    public class RoomStatusController : ApiController
    {
        private RoomManagerEntities db = new RoomManagerEntities();

        // GET: api/Room_Status
        public IQueryable<Room_Status> GetRoomStatus()
        {
            return db.Room_Status;
        }

        // GET: api/Room_Status/5
        [ResponseType(typeof(Room_Status))]
        public IHttpActionResult GetRoom_Status(string id)
        {
            Room_Status room_Status = db.Room_Status.Find(id);
            if (room_Status == null)
            {
                return NotFound();
            }

            return Ok(room_Status);
        }

        // PUT: api/Room_Status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom_Status(string id, Room_Status room_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_Status.id_RoomStatus)
            {
                return BadRequest();
            }

            db.Entry(room_Status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Room_StatusExists(id))
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

        // POST: api/Room_Status
        [ResponseType(typeof(Room_Status))]
        public IHttpActionResult PostRoom_Status(Room_Status room_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Room_Status.Add(room_Status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Room_StatusExists(room_Status.id_RoomStatus))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = room_Status.id_RoomStatus }, room_Status);
        }

        // DELETE: api/Room_Status/5
        [ResponseType(typeof(Room_Status))]
        public IHttpActionResult DeleteRoom_Status(string id)
        {
            Room_Status room_Status = db.Room_Status.Find(id);
            if (room_Status == null)
            {
                return NotFound();
            }

            db.Room_Status.Remove(room_Status);
            db.SaveChanges();

            return Ok(room_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Room_StatusExists(string id)
        {
            return db.Room_Status.Count(e => e.id_RoomStatus == id) > 0;
        }
    }
}