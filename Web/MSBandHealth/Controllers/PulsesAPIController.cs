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
    builder.EntitySet<Pulse>("PulsesAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PulsesAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/PulsesAPI
        [EnableQuery]
        public IQueryable<Pulse> GetPulsesAPI()
        {
            return db.Pulses;
        }

        // GET: odata/PulsesAPI(5)
        [EnableQuery]
        public SingleResult<Pulse> GetPulse([FromODataUri] int key)
        {
            return SingleResult.Create(db.Pulses.Where(pulse => pulse.Id == key));
        }

        // PUT: odata/PulsesAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Pulse> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pulse pulse = db.Pulses.Find(key);
            if (pulse == null)
            {
                return NotFound();
            }

            patch.Put(pulse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pulse);
        }

        // POST: odata/PulsesAPI
        public IHttpActionResult Post(Pulse pulse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pulses.Add(pulse);
            db.SaveChanges();

            return Created(pulse);
        }

        // PATCH: odata/PulsesAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Pulse> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pulse pulse = db.Pulses.Find(key);
            if (pulse == null)
            {
                return NotFound();
            }

            patch.Patch(pulse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pulse);
        }

        // DELETE: odata/PulsesAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Pulse pulse = db.Pulses.Find(key);
            if (pulse == null)
            {
                return NotFound();
            }

            db.Pulses.Remove(pulse);
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

        private bool PulseExists(int key)
        {
            return db.Pulses.Count(e => e.Id == key) > 0;
        }
    }
}
