using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1.Models
{
    public class sanctuary
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Ubicación")]
        [MaxLength(50)]
        public string Ubicacion { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Biodiversidad")]
        [MaxLength(50)]
        public biodiversity Biodiversidad { get; set; }
    }
}