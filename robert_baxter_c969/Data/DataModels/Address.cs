using robert_baxter_c969.Configuration;

namespace robert_baxter_c969.Data.DataModels
{
    public class Address : DataEntity
    {
        [ColumnName("addressId")]
        public override int Id { get; set; }

        [ColumnName("address")]
        public string AddressLine1 { get; set; }

        [ColumnName("address2")]
        public string AddressLine2 { get; set; }

        [ColumnName("phone")]
        public string PhoneNumber { get; set; }

        [ColumnName("cityId")]
        public int CityId { get; set; }

        [ColumnName("postalCode")]
        public string ZipCode { get; set; }
    }
}
