using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Prj.EF;
using Ls.Prj.Entity;
using Ls.Prj.EFRepository;
using AutoMapper;
using Ls.Prj.DTO;

namespace Ls.Prj.Helpers
{
    public class CategoryHelper
    {
        //secondo me la logica di mapping e l'istanziazione della repository andrebbero spostate nel basehelper con uso generic...
        //il mapping si può sovrascrivere nella classe specializzata??....
        private CategoryEFRepository ObjCategoryEFRepository;
        private IMapper mapper;
        private MapperConfiguration config;
        public CategoryHelper(string Username)
            
        {
            ObjCategoryEFRepository = new CategoryEFRepository(Username);
            InitializeMapper();
        }
        public CategoryHelper()
        {
            InitializeMapper();
        }

        private void InitializeMapper()
        {
            _setObjectsMapperConfig();
            mapper = config.CreateMapper();
        }

      

        //sarebbe da esporre la repository per le operazioni semplici? ma viene meno l'utilizzo dei dto
        public Categorie InsertCategory(Categorie CurCat )
        {
            ////senza usare la repositoriEF....
            //using (var context = new PrjDbContext())
            //{
            //    context.SetCurrentUser("Luca Schiavon");
            //    context.Categories.Add(new Categorie() { Categoria = CurCat.Categoria });

            //    context.SaveChanges();

            //    return CurCat;
            //}


            //usando la repository
           

            ObjCategoryEFRepository.Add(CurCat);
            ObjCategoryEFRepository.Save();
            return CurCat;
        }

        public List<CategoriaDTO> GetCategorieDTO()
        {
            List<Categorie> LstCat = ObjCategoryEFRepository.GetAll().ToList();
            var results = mapper.Map<List<Categorie>, List<CategoriaDTO>>(LstCat);
            return results;
        }
        protected virtual void _setObjectsMapperConfig()
        {
            config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Categorie, CategoriaDTO>()
                  //.ForMember(result => result.Categoria, from => from.MapFrom(source => source.Categoria))
                  //   .ForMember(result => result.Ordine, from => from.MapFrom(source => source.Ordine))
                  ;
            });

        }

    }
}
