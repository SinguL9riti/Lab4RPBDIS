using Lab4RPBDIS.Models;
using Route = Lab4RPBDIS.Models.Route;

namespace Lab4RPBDIS.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Personnel> Personnels { get; set; }

        public IEnumerable<RouteViewModel> Routes { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }

        public IEnumerable<Stop> Stops { get; set; }
    }
}
