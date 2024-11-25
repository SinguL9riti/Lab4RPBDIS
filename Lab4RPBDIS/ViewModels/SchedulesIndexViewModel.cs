using Lab4RPBDIS.Models;

namespace Lab4RPBDIS.ViewModels
{
    public class SchedulesIndexViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
