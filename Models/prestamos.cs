namespace AusnerMiranda_Proyecto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prestamos
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string cedula { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string codigo { get; set; }
    }
}
