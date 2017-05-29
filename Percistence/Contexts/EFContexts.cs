using Model.Registers;
using Model.Tables;
using System.Data.Entity;


namespace Persistence.Contexts
{
    public class EFContexts : DbContext
    {
        #region [ DbSet Properties ]
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion [ DbSet Properties ]

        #region [ Construtor ]
                public EFContexts(): base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContexts>(new DropCreateDatabaseIfModelChanges<EFContexts>());
        }
        #endregion [ Construtor ]
    }

}