
using System.Web.OData.Builder;
using Ls.Prj.Entity;


namespace Ls.Prj.WebApi.OData
{
    public class PrjOdataModelBuilder: ODataConventionModelBuilder
    {
        public PrjOdataModelBuilder()
        {
            EntitySet<Categorie>("Categoria").EntityType.HasKey(x => x.Id);
            EntitySet<Prodotti>("Prodotto").EntityType.HasKey(x => x.Id);
            EntitySet<Ordini>("Ordine").EntityType.HasKey(x => x.Id);
        }
           
          
    }
}