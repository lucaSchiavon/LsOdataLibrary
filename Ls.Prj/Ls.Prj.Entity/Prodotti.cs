using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.Entity;

namespace Ls.Prj.Entity
{
    public partial class Prodotti: LsEntity
    {

        public Prodotti()
        {
            OrdiniSuProdottis = new HashSet<OrdiniSuProdotti>();
        }

      
        //public int IdProdotto { get; set; }

   
        public string Prodotto { get; set; }

        public int? IdCategoria { get; set; }

        #region [ navigation property ]
        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<OrdiniSuProdotti> OrdiniSuProdottis { get; set; }
        #endregion
    }
}
