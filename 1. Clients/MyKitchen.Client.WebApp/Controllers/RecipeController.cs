using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyKitchen.DataContracts;
using MyKitchen.Managers;
using MyKitchen.Accessors;
using MyKitchen.Accessors.Contexts;

namespace MyKitchen_Client_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {

        public RecipeController(IRecipeManager manager)
        {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        private IRecipeManager Manager { get; }


        [HttpGet("[action]")]
        public IEnumerable<Recipe> GetAll()
        {
            return Manager.GetAll();
        }
    }
}