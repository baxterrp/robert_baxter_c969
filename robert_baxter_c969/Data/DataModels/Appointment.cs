using robert_baxter_c969.Configuration;
using System;

namespace robert_baxter_c969.Data.DataModels
{
    public class Appointment : DataEntity
    {
        [ColumnName("appointmentId")]
        public override int Id { get; set; }

        [ColumnName("customerId")]
        public int CustomerId { get; set; }

        [ColumnName("userId")]
        public int UserId { get; set; }

        [ColumnName("title")]
        public string Title { get; set; }

        [ColumnName("description")]
        public string Description { get; set; }

        [ColumnName("location")]
        public string Location { get; set; }

        [ColumnName("contact")]
        public string Contact { get; set; }

        [ColumnName("type")]
        public string Type { get; set; }

        [ColumnName("url")]
        public string Url { get; set; }

        [ColumnName("start")]
        public DateTime Start { get; set; }

        [ColumnName("end")]
        public DateTime End { get; set; }

    }
}
