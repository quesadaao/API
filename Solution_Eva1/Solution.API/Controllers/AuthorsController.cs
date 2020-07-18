using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Solution.API.Controllers
{   

    public class AuthorsController : ApiController
    {
        private BS.Authors bs = new BS.Authors();
        // GET: api/Authors
        public IQueryable<Authors2> GetAuthors()
        {
            return bs.GetAll().AsQueryable();
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Authors2))]
        public IHttpActionResult Getauthors2(int id)
        {
            Authors2 employees = bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthors2(int id, Authors2 authors2)
        {
            if (id != authors2.au_id)
            {
                return BadRequest();
            }

            try
            {
                bs.Updated(authors2);

            }
            catch (Exception ee)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Authors2))]
        public IHttpActionResult Postauthors2(Authors2 authors2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bs.Insert(authors2);
            Authors2 newEmp = bs.SearchByFirstName(authors2.au_fname).LastOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = newEmp.au_id }, newEmp);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Authors2))]
        public IHttpActionResult Deleteauthors2(int id)
        {
            Authors2 employees = bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }

            bs.Delete(employees);
            return Ok(employees);
        }

        private bool AuthorsExists(int id)
        {
            return bs.GetOneById(id) != null ? true : false;
        }
    }
}
