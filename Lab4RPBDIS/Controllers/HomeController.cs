using Lab4RPBDIS.Models;
using Lab4RPBDIS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab4RPBDIS.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class HomeController : Controller
    {
        private readonly IViewModelService _inspectionService;

        // Конструктор контроллера с внедрением зависимости
        public HomeController(IViewModelService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        public IActionResult Index()
        {
            return View(_inspectionService.GetHomeViewModel(10));
        }
    }
}
