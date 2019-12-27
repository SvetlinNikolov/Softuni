using Drinks.Data.Contracts;
using Drinks.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Drinks.Web.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IDrinkRepository drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            this.categoryRepository = categoryRepository;
            this.drinkRepository = drinkRepository;
        }

        [HttpGet]
        public ViewResult List()
        {
            var drinks = drinkRepository.Drinks;

            DrinkListViewModel viewModel = new DrinkListViewModel();
            viewModel.Drinks = drinks;
            viewModel.CurrentCategory = "DrinkCategory";
            return View(viewModel);
        }
    }
}
