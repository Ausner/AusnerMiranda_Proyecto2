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
    public class herramientasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/herramientas
        public IQueryable<herramientas> Getherramientas()
        {
            return db.herramientas;
        }

        // GET: api/herramientas/5
        [ResponseType(typeof(herramientas))]
        public IHttpActionResult Getherramientas(string id)
        {
            herramientas herramientas = db.herramientas.Find(id);
            if (herramientas == null)
            {
                return NotFound();
            }

            return Ok(herramientas);
        }

        // PUT: api/herramientas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putherramientas(string id, herramientas herramientas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != herramientas.codigo)
            {
                return BadRequest();
            }

            db.Entry(herramientas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!herramientasExists(id))
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

        // POST: api/herramientas
        [ResponseType(typeof(herramientas))]
        public IHttpActionResult Postherramientas(herramientas herramientas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.herramientas.Add(herramientas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (herramientasExists(herramientas.codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = herramientas.codigo }, herramientas);
        }

        // DELETE: api/herramientas/5
        [ResponseType(typeof(herramientas))]
        public IHttpActionResult Deleteherramientas(string id)
        {
            herramientas herramientas = db.herramientas.Find(id);
            if (herramientas == null)
            {
                return NotFound();
            }

            db.herramientas.Remove(herramientas);
            db.SaveChanges();

            return Ok(herramientas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool herramientasExists(string id)
        {
            return db.herramientas.Count(e => e.codigo == id) > 0;
        }
    }
}