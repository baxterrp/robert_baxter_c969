using System;
using System.ComponentModel.DataAnnotations;

namespace robert_baxter_c969.Data
{
    public abstract class DataEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdate { get; set; }

        [MaxLength(40)]
        public string CreatedBy { get; set; }

        [MaxLength(40)]
        public string LastUpdateBy { get; set; }
    }
}
