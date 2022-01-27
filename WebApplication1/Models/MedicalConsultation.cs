namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicalConsultation")]
    public partial class MedicalConsultation
    {
        public int id { get; set; }

        public int id_med { get; set; }

        public int id_pat { get; set; }

        public int? RoomNumber { get; set; }

        public DateTime? DateOfmedicalconsultation { get; set; }

        public int? id_pres { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
