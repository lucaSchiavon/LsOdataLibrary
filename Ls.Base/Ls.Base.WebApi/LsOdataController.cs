using System;
using System.Linq;
using System.Threading.Tasks;
using Ls.Base.EF;
using Ls.Base.Entity;
using System.Net;
using System.Web.Http;
using System.Web.OData;

namespace Ls.Base.WebApi
{
    public class LsOdataController<C,T> : ODataController
       where C : LsDbContext, new() where T : LsEntity
    {
        protected virtual C db { get; set; }
       // protected virtual Ls.Base.EF.IdbContext db { get; set; }
        //protected IJsonSerializerSettings SerializerSettings;
        //protected ILog Logger;

        public LsOdataController()
        {
            db = new C();
        //db = new LsDbContext("EcommerceTestModelConn");
           // db = (IEnerjDbContext)(GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IEnerjDbContext)));
            //db.SetCurrentUser(User.Identity.Name);

            //Logger = (ILog)(GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILog)));
            //SerializerSettings = (IJsonSerializerSettings)(GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IJsonSerializerSettings)));
        }

        // GET: odata/T        
        [EnableQuery]
        public IQueryable<T> Get() => db.Set<T>();

        // GET: odata/T(key)
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<T> Get([FromODataUri] int key) => SingleResult.Create(db.Set<T>().Where(x => x.Id == key));

        // PUT: odata/tokens(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<T> patch)
        {
            //Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T entity = await db.Set<T>().FindAsync(key);
            if (entity == null)
                //return NotFound();
                return new LsInternalServerError(this, $"entity con chiave {key} non trovata");

            patch.Put(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Updated(entity);
        }

        // POST: odata/T
        public async Task<IHttpActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Set<T>().Add(entity);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            //Logger.WriteInfoLog($"Entity ${typeof(T).Name} creata correttamente - user: {User.Identity.Name}", null, "EnerjOdataController");
            return Created(entity);
        }

        // PATCH: odata/T(key)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<T> patch)
        {
            //Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T entity = await db.Set<T>().FindAsync(key);
            if (entity == null)
                return InternalServerError(new Exception($"entity con chiave {key} non trovata"));

            patch.Patch(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                return InternalServerError(new Exception(exc.ToString()));
            }

            //Logger.WriteInfoLog($"Entity ${typeof(T).Name} con chiave {key} modificata correttamente - user: {User.Identity.Name}", null, "EnerjOdataController");
            return Updated(entity);
        }

        // DELETE: odata/T(key)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            T entity = await db.Set<T>().FindAsync(key);
            if (entity == null)
                return InternalServerError(new Exception($"entity con chiave {key} non trovata"));


            try
            {
                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                return InternalServerError(new Exception(exc.ToString()));
            }

           // Logger.WriteInfoLog($"Entity ${typeof(T).Name} con chiave {key} eliminata correttamente - user: {User.Identity.Name}", null, "EnerjOdataController");

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool entityExists(int key) => db.Set<T>().Count(e => e.Id == key) > 0;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
