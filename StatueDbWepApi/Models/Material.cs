namespace StatueDbWepApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            MaterialList = new HashSet<MaterialList>();
        }

        public int Id { get; set; }

        [Column("Material")]
        [Required]
        [StringLength(50)]
        public string Material1 { get; set; }

        [Required]
        [StringLength(1)]
        public string Types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialList> MaterialList { get; set; }
    }
}
