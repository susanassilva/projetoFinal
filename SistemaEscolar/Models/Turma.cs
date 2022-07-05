using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SistemaEscolar.Models
{
    public class Turma
    {

        public int id { get; set; }
        public string nome { get; set; }

        public bool? ativo { get; set; }

        
        public virtual List<Aluno>? Aluno { get; set; }

        
    }
}
