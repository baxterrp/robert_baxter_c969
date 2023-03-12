using robert_baxter_c969.Configuration;
using System.ComponentModel.DataAnnotations;

namespace robert_baxter_c969.Data.Models
{
    public class User : DataEntity
    {
        [ColumnName("userId")]
        public override int Id { get; set; }

        [MaxLength(50)]
        [ColumnName("userName")]
        public string UserName { get; set; }

        [MaxLength(50)]
        [ColumnName("password")]
        public string Password { get; set; }

        [ColumnName("active")]
        public bool Active { get; set; }
    }
}
