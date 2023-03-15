using robert_baxter_c969.Configuration;
using System;

namespace robert_baxter_c969.Data.ViewModels
{
    public class AppointmentViewModel
    {
        [ColumnName("Id")]
        public int Id { get; set; }

        [ColumnName("Customer")]
        public string Customer { get; set; }

        [ColumnName("Title")]
        public string Title { get; set; }

        [ColumnName("Location")]
        public string Location { get; set; }

        [ColumnName("Description")]
        public string Description { get; set; }

        [ColumnName("Contact")]
        public string Contact { get; set; }

        [ColumnName("Type")]
        public string Type { get; set; }

        [ColumnName("StartTime")]
        public DateTime StartTime { get; set; }

        [ColumnName("EndTime")]
        public DateTime EndTime { get; set; }
    }
}
