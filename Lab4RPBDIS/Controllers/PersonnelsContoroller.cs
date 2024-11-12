using Microsoft.AspNetCore.Mvc;
using Lab4RPBDIS.Services;

namespace Lab4RPBDIS.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class PersonnelsController : Controller
    {
        private readonly IViewModelService _viewModelService;

        // Конструктор контроллера с внедрением зависимости
        public PersonnelsController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            return View(_viewModelService.GetHomeViewModel(30));
        }
    }
}
