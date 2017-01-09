using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ls.Prj.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Prj.Entity;
using Ls.Prj.DTO;

namespace Ls.Prj.Helpers.Tests
{
    [TestClass()]
    public class CategoryHelperTests
    {
        CategoryHelper ObjCatHelper = new CategoryHelper("Luca Schiavon");
        [TestMethod()]
        public void InsertCategoryTest()
        {
           
            //qui dto al posto di entity
            Categorie ObjCat = ObjCatHelper.InsertCategory(new Categorie { Categoria = "decima categoria" });
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategorieDTOTest()
        {
            List<CategoriaDTO> LstCatDto = ObjCatHelper.GetCategorieDTO();
            Assert.Fail();
        }
    }
}