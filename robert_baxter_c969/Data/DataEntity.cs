using robert_baxter_c969.Configuration;
using System;
using System.ComponentModel.DataAnnotations;

namespace robert_baxter_c969.Data
{
    public abstract class DataEntity
    {
        public abstract int Id { get; set; }

        [ColumnName("createDate")]
        public DateTime CreateDate { get; set; }
        
        [ColumnName("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [MaxLength(40)]
        [ColumnName("createdBy")]
        public string CreatedBy { get; set; }

        [MaxLength(40)]
        [ColumnName("lastUpdateBy")]
        public string LastUpdateBy { get; set; }
    }
}
