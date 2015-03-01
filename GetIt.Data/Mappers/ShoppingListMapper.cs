using GetIt.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Mappers
{
    public class ShoppingListMapper : EntityTypeConfiguration<ShoppingList>
    {
        public ShoppingListMapper()
        {

            this.ToTable("ShoppingLists");

            this.HasKey(s => s.ShoppingListId);
            this.Property(s => s.ShoppingListId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ShoppingListId).IsRequired();

            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Name).HasMaxLength(100);
        }

    }
}
