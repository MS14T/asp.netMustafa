using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mustafa24.Models.Model
{
    [Table("Hizmet")]
    public class Hizmet
    {
        [Key]
        public int HizmetId { get; set; }
        [Required,StringLength(150, ErrorMessage ="150 karakter olmalidir.")]
        [DisplayName("Hizmet Baslik")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet resim")]
        public string ResimURL { get; set; }
    }
}