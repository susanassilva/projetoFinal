namespace SistemaEscolar.Models
{
    public class Aluno
    {
        #region Properties
        public int id { get; set; }
        public string nome { get; set; }

        public string sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }

        public char sexo { get; set; }
        public int turmaId { get; set; }

        public int? totalFaltas { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Turma? Turma { get; set; }

        #endregion
    }
}
