using SoftUniRestaurant.Core;
using SoftUniRestaurant.Core.Engine;
using SoftUniRestaurant.Models.Drinks.Entities;
using SoftUniRestaurant.Models.Tables.Contracts.Entities;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
          

            Engine engine = new Engine();
            engine.Run();

           
        }
    }
}
