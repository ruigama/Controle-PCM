using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_PCM.Models
{
    [Table("anexos")]
    public class Anexo
    {
        [Key]
        public int id { get; set; }
        public string anexo { get; set; }
        public int id_formulario { get; set; }
        public Informacoes Informacoes { get; set; }
    }
}
