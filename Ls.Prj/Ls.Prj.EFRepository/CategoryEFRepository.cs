using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.EFRepository;
using Ls.Prj.EF;
using Ls.Prj.Entity;
using AutoMapper;
using Ls.Prj.DTO;

namespace Ls.Prj.EFRepository
{
    public class CategoryEFRepository : GenericEFRepository<PrjDbContext, Categorie>
    {
        public CategoryEFRepository(string Username)
            : base (Username)
        {
            //this.Context.SetCurrentUser(Username);
        }
        //qui possiamo inserire altri metodi specifici per estrarre  categorie
       
    }
}
