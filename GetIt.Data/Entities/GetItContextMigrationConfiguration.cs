using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    class GetItContextMigrationConfiguration : DbMigrationsConfiguration<GetItContext>
    {
        public GetItContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GetItContext context)
        {
            //var itemOne = new ShoppingItem() {Name = "Item One", Notes = "Item One Notes", Qty = 1, IsComplete = false};
            //var itemTwo =  new ShoppingItem() {Name = "Item Two", Notes = "Item Two Notes", Qty = 2, IsComplete = true};
            //var testList = new ShoppingList() {Name = "Test List", Items = new List<ShoppingItem>() {itemOne, itemTwo}};

            //context.ShoppingLists.AddOrUpdate(testList);
            //context.SaveChanges();
        }
    }

}
