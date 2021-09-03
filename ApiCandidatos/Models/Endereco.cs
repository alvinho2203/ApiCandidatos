using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCandidatos.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [StringLength(150)]
        public string Local { get; set; }
        [StringLength(100)]
        public string Cidade { get; set; }
        [StringLength(100)]
        public string Estado { get; set; }
    }
}