using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_PCM.Models
{
    [Table("formulario")]
    public class Informacoes
    {
        [Key]
        public int? id { get; set; }
        public string codigo { get; set; }
        public string modelo { get; set; }
        public string aspecto_tecnico { get; set; }
        public string preco_nova { get; set; }
        public string custo { get; set; }
        public string preco_atual { get; set; }
        public string avaliacao_tecnica { get; set; }
        public int status { get; set; }
    }
}
