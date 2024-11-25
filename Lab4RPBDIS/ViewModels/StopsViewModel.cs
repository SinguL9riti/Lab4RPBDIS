using Lab4RPBDIS.Models;

namespace Lab4RPBDIS.ViewModels
{
    public class StopsViewModel
    {
        public IEnumerable<Stop> Stops { get; set; } = Enumerable.Empty<Stop>();
        public PageViewModel PageViewModel { get; set; }
    }
}
