namespace FlowerPot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class СonfirmOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public СonfirmOrder()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_conforder { get; set; }

        public int? id_user { get; set; }

        public int? id_product { get; set; }

        public int? total_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        public virtual Products Products { get; set; }

        public virtual UserAuth UserAuth { get; set; }
    }
}
