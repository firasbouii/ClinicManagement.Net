namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prescription")]
    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            MedicalConsultation = new HashSet<MedicalConsultation>();
        }

        public int id { get; set; }

        public int? id_doc { get; set; }

        public int? id_pat { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(50)]
        public string medicine { get; set; }

        public virtual Doctor Doctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalConsultation> MedicalConsultation { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
