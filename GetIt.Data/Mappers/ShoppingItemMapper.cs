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
    public class ShoppingItemMapper : EntityTypeConfiguration<ShoppingItem>
    {
        public ShoppingItemMapper()
        {
            this.ToTable("ShoppingItems");

            this.HasKey(s => s.ShoppingItemId);
            this.Property(s => s.ShoppingItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ShoppingItemId).IsRequired();

            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Name).HasMaxLength(100);

            this.Property(s => s.Notes).HasMaxLength(1000);

            this.HasRequired(s => s.ParentShoppingList);
        }
    }
}
