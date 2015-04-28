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
    builder.EntitySet<Step>("StepsAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StepsAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/StepsAPI
        [EnableQuery]
        public IQueryable<Step> GetStepsAPI()
        {
            return db.Steps;
        }

        // GET: odata/StepsAPI(5)
        [EnableQuery]
        public SingleResult<Step> GetStep([FromODataUri] int key)
        {
            return SingleResult.Create(db.Steps.Where(step => step.Id == key));
        }

        // PUT: odata/StepsAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Step> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Step step = db.Steps.Find(key);
            if (step == null)
            {
                return NotFound();
            }

            patch.Put(step);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(step);
        }

        // POST: odata/StepsAPI
        public IHttpActionResult Post(Step step)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Steps.Add(step);
            db.SaveChanges();

            return Created(step);
        }

        // PATCH: odata/StepsAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Step> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Step step = db.Steps.Find(key);
            if (step == null)
            {
                return NotFound();
            }

            patch.Patch(step);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(step);
        }

        // DELETE: odata/StepsAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Step step = db.Steps.Find(key);
            if (step == null)
            {
                return NotFound();
            }

            db.Steps.Remove(step);
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

        private bool StepExists(int key)
        {
            return db.Steps.Count(e => e.Id == key) > 0;
        }
    }
}
