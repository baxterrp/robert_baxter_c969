using robert_baxter_c969.Configuration;

namespace robert_baxter_c969.Data.DataModels
{
    public class City : DataEntity
    {
        [ColumnName("CityId")]
        public override int Id { get; set; }

        [ColumnName("city")]
        public string Name { get; set; }

        [ColumnName("countryId")]
        public int CountryId { get; set; }
    }
}
