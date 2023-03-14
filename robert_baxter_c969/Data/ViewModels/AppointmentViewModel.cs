using System;

namespace robert_baxter_c969.Data.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Customer { get; set; }
    }
}
