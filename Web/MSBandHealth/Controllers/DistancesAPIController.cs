using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using MSBandHealth.Models;

namespace MSBandHealth.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using MSBandHealth.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Distance>("DistancesAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DistancesAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/DistancesAPI
        [EnableQuery]
        public IQueryable<Distance> GetDistancesAPI()
        {
            return db.Distances;
        }

        // GET: odata/DistancesAPI(5)
        [EnableQuery]
        public SingleResult<Distance> GetDistance([FromODataUri] int key)
        {
            return SingleResult.Create(db.Distances.Where(distance => distance.Id == key));
        }

        // PUT: odata/DistancesAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Distance> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Distance distance = db.Distances.Find(key);
            if (distance == null)
            {
                return NotFound();
            }

            patch.Put(distance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistanceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(distance);
        }

        // POST: odata/DistancesAPI
        public IHttpActionResult Post(Distance distance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distances.Add(distance);
            db.SaveChanges();

            return Created(distance);
        }

        // PATCH: odata/DistancesAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Distance> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Distance distance = db.Distances.Find(key);
            if (distance == null)
            {
                return NotFound();
            }

            patch.Patch(distance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistanceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(distance);
        }

        // DELETE: odata/DistancesAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Distance distance = db.Distances.Find(key);
            if (distance == null)
            {
                return NotFound();
            }

            db.Distances.Remove(distance);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistanceExists(int key)
        {
            return db.Distances.Count(e => e.Id == key) > 0;
        }
    }
}
