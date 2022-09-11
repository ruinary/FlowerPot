namespace FlowerPot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Cart = new HashSet<Cart>();
            СonfirmOrder = new HashSet<СonfirmOrder>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_product { get; set; }

        [StringLength(20)]
        public string name_product { get; set; }

        [StringLength(80)]
        public string fullname_product { get; set; }

        [StringLength(200)]
        public string discription_product { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_product { get; set; }

        [StringLength(200)]
        public string img_path { get; set; }

        public int? amount { get; set; }

        [StringLength(200)]
        public string model_path { get; set; }

        public int? id_flower_type { get; set; }

        public int? id_color_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        public virtual Catagory Catagory { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<СonfirmOrder> СonfirmOrder { get; set; }
    }
}
