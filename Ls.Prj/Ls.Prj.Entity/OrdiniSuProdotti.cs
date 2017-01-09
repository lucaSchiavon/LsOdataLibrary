using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.Entity;

namespace Ls.Prj.Entity
{
    public partial class OrdiniSuProdotti : LsEntity
    {
        
        //public int IdOrdineSuProdotto { get; set; }

        public int? IdOrdine { get; set; }

        public int? IdProdotto { get; set; }

        public int? qta { get; set; }

        #region [ navigation property ]
        public virtual Ordini Ordini { get; set; }

        public virtual Prodotti Prodotti { get; set; }
        #endregion
    }
}
