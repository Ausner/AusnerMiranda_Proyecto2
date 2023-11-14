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
using System.Web.Mvc;

namespace AusnerMiranda_Proyecto2.Controllers
{
    public class colaboradorsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/colaboradors
        public IQueryable<colaborador> Getcolaborador()
        {
            return db.colaborador;
        }

        // GET: api/colaboradors/5
        [ResponseType(typeof(colaborador))]
        public IHttpActionResult Getcolaborador(string id)
        {
            colaborador colaborador = db.colaborador.Find(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

        // PUT: api/colaboradors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcolaborador(string id, colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colaborador.cedula)
            {
                return BadRequest();
            }

            db.Entry(colaborador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!colaboradorExists(id))
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

        // POST: api/colaboradors
        [ResponseType(typeof(colaborador))]
        public IHttpActionResult Postcolaborador(colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.colaborador.Add(colaborador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (colaboradorExists(colaborador.cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colaborador.cedula }, colaborador);
        }

        // DELETE: api/colaboradors/5
        [ResponseType(typeof(colaborador))]
        public IHttpActionResult Deletecolaborador(string id)
        {
            colaborador colaborador = db.colaborador.Find(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            db.colaborador.Remove(colaborador);
            db.SaveChanges();

            return Ok(colaborador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool colaboradorExists(string id)
        {
            return db.colaborador.Count(e => e.cedula == id) > 0;
        }
    }
}