using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ls.Base.WebApi;
using Ls.Prj.Entity;
using Ls.Prj.EF;


namespace Ls.Prj.WebApi.Controllers
{
    public class CategoriaController : LsOdataController<PrjDbContext,Categorie>
    {
    }
}
