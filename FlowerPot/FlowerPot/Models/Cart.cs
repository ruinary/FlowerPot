namespace FlowerPot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cart { get; set; }

        public int? id_user { get; set; }

        public int? id_product { get; set; }

        public int? total_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_price { get; set; }

        public virtual Products Products { get; set; }

        public virtual UserAuth UserAuth { get; set; }
    }
}
