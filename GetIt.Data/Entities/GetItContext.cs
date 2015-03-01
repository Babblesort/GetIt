using GetIt.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    public class GetItContext : DbContext
    {
        public GetItContext() : base("GetItConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetItContext, GetItContextMigrationConfiguration>());
        }

        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ShoppingListMapper());
            modelBuilder.Configurations.Add(new ShoppingItemMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
