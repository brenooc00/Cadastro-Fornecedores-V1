using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroFornecedores.Models
{
    public class ContatoModel
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string nome { get; set; }
        [StringLength(14, MinimumLength = 14)]
        public string cnpj { get; set; }
        [Required]
        public string segmento { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string cep { get; set; }
        [MaxLength(255)]
        public string endereco { get; set; }
    }
}