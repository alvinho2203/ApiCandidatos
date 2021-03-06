using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCandidatos.Models
{
    [Table("Candidatos")]
    public class Candidatos
    {
        [Key]
        public int CandidatoId { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Telefone { get; set; }
        [StringLength(40)]
        public string Vaga { get; set; }
        [Required]
        public virtual Endereco Endereco { get; set; }
        public virtual int EnderecoId { get; set; }
    }
}