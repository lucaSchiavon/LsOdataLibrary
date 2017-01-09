using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Base.EF;
using System.Data.Entity;
using Ls.Prj.Entity;
using Ls.Prj.EF.TypeConfigurations;

namespace Ls.Prj.EF
{
    public partial class PrjDbContext : LsDbContext
    {
        public PrjDbContext()
            : base("EcommerceTestModelConn")
        {
        }
        private const string schema = "dbo";

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Ordini> Ordinis { get; set; }
        public virtual DbSet<OrdiniSuProdotti> OrdiniSuProdottis { get; set; }
        public virtual DbSet<Prodotti> Prodottis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //anzichè avere datanotation è possibile aggiungere le configurazioni al model builder aggiungendo
            //oggetti di tipo EntityTypeConfiguration<T>
            modelBuilder.Configurations.Add(new CategorieTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new ProdottiTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new OrdiniTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new OrdiniSuProdottiTypeConfiguration(schema));
        }
    }
}
