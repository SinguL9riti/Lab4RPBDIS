using Lab4RPBDIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4RPBDIS.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class SchedulesController : Controller
    {
        private readonly IViewModelService _viewModelService;

        // Конструктор контроллера с внедрением зависимости
        public SchedulesController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            return View(_viewModelService.GetHomeViewModel(30));
        }
    }
}
