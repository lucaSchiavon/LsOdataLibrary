using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.EFRepository;
using Ls.Prj.EF;
using Ls.Prj.Entity;

namespace Ls.Prj.EFRepository
{
    public class OrdiniEFRepository : GenericEFRepository<PrjDbContext, Ordini>
    {
        //qui possiamo inserire altri metodi specifici per estrarre  categorie
    }
}
