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
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    public class authors2Controller : ApiController
    {
        private TinEntities1 db = new TinEntities1();

        // GET: api/authors2
        public IQueryable<authors2> Getauthors2()
        {
            return db.authors2;
        }

        // GET: api/authors2/5
        [ResponseType(typeof(authors2))]
        public IHttpActionResult Getauthors2(int id)
        {
            authors2 authors2 = db.authors2.Find(id);
            if (authors2 == null)
            {
                return NotFound();
            }

            return Ok(authors2);
        }

        // PUT: api/authors2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthors2(int id, authors2 authors2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authors2.au_id)
            {
                return BadRequest();
            }

            db.Entry(authors2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!authors2Exists(id))
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

        // POST: api/authors2
        [ResponseType(typeof(authors2))]
        public IHttpActionResult Postauthors2(authors2 authors2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.authors2.Add(authors2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authors2.au_id }, authors2);
        }

        // DELETE: api/authors2/5
        [ResponseType(typeof(authors2))]
        public IHttpActionResult Deleteauthors2(int id)
        {
            authors2 authors2 = db.authors2.Find(id);
            if (authors2 == null)
            {
                return NotFound();
            }

            db.authors2.Remove(authors2);
            db.SaveChanges();

            return Ok(authors2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authors2Exists(int id)
        {
            return db.authors2.Count(e => e.au_id == id) > 0;
        }
    }
}