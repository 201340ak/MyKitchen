using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyKitchen.Accessors;
using MyKitchen.Accessors.Contexts;
using MyKitchen.Clients;
using MyKitchen.Managers;
using MyKitchen_Client_WebApp.Controllers;

namespace MyKitchen.Clients.Tests
{
    [TestClass]
    public class RecipeControllerTests
    {
        private DbContextOptions<MyKitchenDbContext> options = new DbContextOptionsBuilder<MyKitchenDbContext>()
                            .UseSqlServer(@"Server=localhost;Database=MyKitchen;Trusted_Connection=True;")
                            .Options;
        private MyKitchenDbContext MyKicthenContext => new MyKitchenDbContext(options);

        [TestMethod]
        public void GetAll_Integration()
        {
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);

                using(var controller = new RecipeController(manager)){
                    var recipes = controller.GetAll();
                    Assert.IsNotNull(recipes);
                    Assert.AreNotEqual(0, recipes.Count());
                }
            }
        }
    }
}
