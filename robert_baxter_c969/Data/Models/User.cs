using System;
using System.ComponentModel.DataAnnotations;

namespace robert_baxter_c969.Data.Models
{
    public class User : DataEntity
    {
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
