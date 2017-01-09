using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.Entity;


namespace Ls.Prj.Entity
{
    public partial class Categorie : LsEntity
    {

        public Categorie()
        {
            Prodottis = new HashSet<Prodotti>();
        
        }
     
 

        public string Categoria { get; set; }
       
        #region [ navigation property ]
        public virtual ICollection<Prodotti> Prodottis { get; set; }
        #endregion
    }
}
