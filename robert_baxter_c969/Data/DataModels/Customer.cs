using robert_baxter_c969.Configuration;

namespace robert_baxter_c969.Data.Models
{
    public class Customer : DataEntity
    {
        [ColumnName("customerId")]
        public override int Id { get; set; }

        [ColumnName("customerName")]
        public string CustomerName { get; set; }

        [ColumnName("addressId")]
        public int AddressId { get; set; }

        [ColumnName("active")]
        public bool Active { get; set; }
    }
}
