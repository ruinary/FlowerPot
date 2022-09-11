namespace FlowerPot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_order { get; set; }

        public int? id_conforder { get; set; }

        [Column(TypeName = "date")]
        public DateTime now_date { get; set; }

        public int id_order_status { get; set; }

        public virtual СonfirmOrder СonfirmOrder { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
    }
}
