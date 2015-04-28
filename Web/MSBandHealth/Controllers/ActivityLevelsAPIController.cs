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
    builder.EntitySet<ActivityLevel>("ActivityLevelsAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ActivityLevelsAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ActivityLevelsAPI
        [EnableQuery]
        public IQueryable<ActivityLevel> GetActivityLevelsAPI()
        {
            return db.ActivityLevels;
        }

        // GET: odata/ActivityLevelsAPI(5)
        [EnableQuery]
        public SingleResult<ActivityLevel> GetActivityLevel([FromODataUri] int key)
        {
            return SingleResult.Create(db.ActivityLevels.Where(activityLevel => activityLevel.Id == key));
        }

        // PUT: odata/ActivityLevelsAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ActivityLevel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ActivityLevel activityLevel = db.ActivityLevels.Find(key);
            if (activityLevel == null)
            {
                return NotFound();
            }

            patch.Put(activityLevel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLevelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(activityLevel);
        }

        // POST: odata/ActivityLevelsAPI
        public IHttpActionResult Post(ActivityLevel activityLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivityLevels.Add(activityLevel);
            db.SaveChanges();

            return Created(activityLevel);
        }

        // PATCH: odata/ActivityLevelsAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ActivityLevel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ActivityLevel activityLevel = db.ActivityLevels.Find(key);
            if (activityLevel == null)
            {
                return NotFound();
            }

            patch.Patch(activityLevel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLevelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(activityLevel);
        }

        // DELETE: odata/ActivityLevelsAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ActivityLevel activityLevel = db.ActivityLevels.Find(key);
            if (activityLevel == null)
            {
                return NotFound();
            }

            db.ActivityLevels.Remove(activityLevel);
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

        private bool ActivityLevelExists(int key)
        {
            return db.ActivityLevels.Count(e => e.Id == key) > 0;
        }
    }
}
