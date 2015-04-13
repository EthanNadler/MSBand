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
    builder.EntitySet<SkinTemperature>("SkinTemperaturesAPI");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SkinTemperaturesAPIController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/SkinTemperaturesAPI
        [EnableQuery]
        public IQueryable<SkinTemperature> GetSkinTemperaturesAPI()
        {
            return db.SkinTemperatures;
        }

        // GET: odata/SkinTemperaturesAPI(5)
        [EnableQuery]
        public SingleResult<SkinTemperature> GetSkinTemperature([FromODataUri] int key)
        {
            return SingleResult.Create(db.SkinTemperatures.Where(skinTemperature => skinTemperature.Id == key));
        }

        // PUT: odata/SkinTemperaturesAPI(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SkinTemperature> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SkinTemperature skinTemperature = db.SkinTemperatures.Find(key);
            if (skinTemperature == null)
            {
                return NotFound();
            }

            patch.Put(skinTemperature);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinTemperatureExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(skinTemperature);
        }

        // POST: odata/SkinTemperaturesAPI
        public IHttpActionResult Post(SkinTemperature skinTemperature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkinTemperatures.Add(skinTemperature);
            db.SaveChanges();

            return Created(skinTemperature);
        }

        // PATCH: odata/SkinTemperaturesAPI(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SkinTemperature> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SkinTemperature skinTemperature = db.SkinTemperatures.Find(key);
            if (skinTemperature == null)
            {
                return NotFound();
            }

            patch.Patch(skinTemperature);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinTemperatureExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(skinTemperature);
        }

        // DELETE: odata/SkinTemperaturesAPI(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            SkinTemperature skinTemperature = db.SkinTemperatures.Find(key);
            if (skinTemperature == null)
            {
                return NotFound();
            }

            db.SkinTemperatures.Remove(skinTemperature);
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

        private bool SkinTemperatureExists(int key)
        {
            return db.SkinTemperatures.Count(e => e.Id == key) > 0;
        }
    }
}
