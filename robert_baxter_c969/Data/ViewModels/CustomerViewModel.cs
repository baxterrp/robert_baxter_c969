using robert_baxter_c969.Configuration;

namespace robert_baxter_c969.Data.ViewModels
{
    public class CustomerViewModel
    {
        [ColumnName("Id")]
        public int Id { get; set; }

        [ColumnName("Name")]
        public string Name { get; set; }

        [ColumnName("AddressLine1")]
        public string AddressLine1 { get; set; }

        [ColumnName("AddressLine2")]
        public string AddressLine2 { get; set; }

        [ColumnName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [ColumnName("ZipCode")]
        public string ZipCode { get; set; }

        [ColumnName("City")]
        public string City { get; set; }

        [ColumnName("Country")]
        public string Country { get; set; }
    }
}
