using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.Entity;

namespace Ls.Prj.Entity
{
    public partial class Ordini : LsEntity
    {
        //
        public Ordini()
        {
            OrdiniSuProdottis = new HashSet<OrdiniSuProdotti>();
        }

        public DateTimeOffset? DataOrdine { get; set; }

        #region [ navigation property ]
        public virtual ICollection<OrdiniSuProdotti> OrdiniSuProdottis { get; set; }
        #endregion
    }
}
