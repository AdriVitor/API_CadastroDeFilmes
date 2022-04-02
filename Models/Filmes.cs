using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models 
{
    [Table("Filmes")]
    public class FilmeModel 
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genero { get; set; }

        public DateTime? DataDeLancamento { get; set; }

        public string Descricao { get; set; }


    }
}