﻿namespace Lab4RPBDIS.ViewModels
{
    public class ScheduleIdViewModel
    {
        public int ScheduleId { get; set; }
        public int RouteId { get; set; }

        public string Weekday { get; set; } = null!;

        public TimeSpan ArrivalTime { get; set; }

        public int Year { get; set; }
    }
}
