namespace AusnerMiranda_Proyecto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("colaborador")]
    public partial class colaborador
    {
        [Key]
        [StringLength(50)]
        public string cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }

        public DateTime fecha_registro { get; set; }

        public bool estado { get; set; }
    }
}
