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
using AusnerMiranda_Proyecto2.Models;

namespace AusnerMiranda_Proyecto2.Controllers
{
    public class prestamosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prestamos
        public IQueryable<prestamos> Getprestamos()
        {
            return db.prestamos;
        }

        // GET: api/prestamos/5
        [ResponseType(typeof(prestamos))]
        public IHttpActionResult Getprestamos(string id)
        {
            prestamos prestamos = db.prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            return Ok(prestamos);
        }

        // PUT: api/prestamos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprestamos(string id, prestamos prestamos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamos.cedula)
            {
                return BadRequest();
            }

            db.Entry(prestamos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prestamosExists(id))
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

        // POST: api/prestamos
        [ResponseType(typeof(prestamos))]
        public IHttpActionResult Postprestamos(prestamos prestamos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prestamos.Add(prestamos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (prestamosExists(prestamos.cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prestamos.cedula }, prestamos);
        }

        // DELETE: api/prestamos/5
        [ResponseType(typeof(prestamos))]
        public IHttpActionResult Deleteprestamos(string id)
        {
            prestamos prestamos = db.prestamos.Find(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            db.prestamos.Remove(prestamos);
            db.SaveChanges();

            return Ok(prestamos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prestamosExists(string id)
        {
            return db.prestamos.Count(e => e.cedula == id) > 0;
        }
    }
}