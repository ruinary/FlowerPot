namespace FlowerPot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int? id_user { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool is_admin { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string First_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Last_Name { get; set; }

        [StringLength(20)]
        public string Midle_Name { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(13)]
        public string phone_num { get; set; }

        [StringLength(200)]
        public string user_img_path { get; set; }

        public virtual UserAuth UserAuth { get; set; }
    }
}
