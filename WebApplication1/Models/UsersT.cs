namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersT")]
    public partial class UsersT
    {
        public int id { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string FirsName { get; set; }

        [StringLength(50)]
        public string password { get; set; }
    }
}
