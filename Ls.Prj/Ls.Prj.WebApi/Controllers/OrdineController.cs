using Ls.Base.WebApi;
using Ls.Prj.EF;
using Ls.Prj.Entity;

namespace Ls.Prj.WebApi.Controllers
{
    public class OrdineController : LsOdataController<PrjDbContext, Ordini>
    {
    }
}
