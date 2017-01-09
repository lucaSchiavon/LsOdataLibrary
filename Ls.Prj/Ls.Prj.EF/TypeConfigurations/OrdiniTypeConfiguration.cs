using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Prj.Entity;
using Ls.Base.EF;

namespace Ls.Prj.EF.TypeConfigurations
{
    public class OrdiniTypeConfiguration : LsEntityTypeConfiguration<Ordini>
    {
        public OrdiniTypeConfiguration(string schema) : 
            base(schema, "IdOrdine")
        {
            ToTable("Ordine");

            #region [ Relations ]
            //HasRequired(e => e.state)
            //    .WithMany(e => e.document_states)
            //    .HasForeignKey(e => e.id_state)
            //    .WillCascadeOnDelete(false);

            HasMany(e => e.OrdiniSuProdottis)
               .WithOptional(e => e.Ordini)
               .HasForeignKey(e => e.IdOrdine)
               .WillCascadeOnDelete(false);

            //HasMany(e => e.storage_states)
            //   .WithOptional(e => e.document_state)
            //   .HasForeignKey(e => e.id_document_state)
            //   .WillCascadeOnDelete(false);

            #endregion
        }
    }
}
