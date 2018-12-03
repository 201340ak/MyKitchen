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
    public class FoodController : Controller
    {

        public FoodController(IFoodManager manager)
        {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        private IFoodManager Manager { get; }


        [HttpGet("[action]")]
        public IEnumerable<Food> GetAll()
        {
            var foods = Manager.GetAll();
            return Manager.GetAll();
        }

        [HttpGet("[action]")]
        public Food GetById([FromBody] int id)
        {
            return Manager.Get(id);
        }

        [HttpPost("[action]")]
        public bool Add([FromBody] Food food)
        {
            try
            {
                var addedFood = Manager.Add(food);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
