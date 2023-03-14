using robert_baxter_c969.Configuration;

namespace robert_baxter_c969.Data.DataModels
{
    public class Country : DataEntity
    {
        [ColumnName("countryId")]
        public override int Id { get; set; }

        [ColumnName("country")]
        public string Name { get; set; }
    }
}
