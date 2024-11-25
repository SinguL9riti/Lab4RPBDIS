using Lab4RPBDIS.Models;
using Route = Lab4RPBDIS.Models.Route;

namespace Lab4RPBDIS.ViewModels
{
    public class RoutesIndexViewModel
    {
        public IEnumerable<Route> Routes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
