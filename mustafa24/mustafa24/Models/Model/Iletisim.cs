using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mustafa24.Models.Model
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        [StringLength(250 , ErrorMessage ="250 karakter olabilir.")]
        public string Adres { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Telefon { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Fax { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Whatsapp { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Facebook { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Twitter { get; set; }
        [StringLength(250, ErrorMessage = "250 karakter olabilir.")]
        public string Instagram { get; set; }
    }
}