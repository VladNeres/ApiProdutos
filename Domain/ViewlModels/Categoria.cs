using System.ComponentModel.DataAnnotations;

namespace Domain.ViewlModels
{
    public class Categoria
    {
        [Key]
        public  int ID { get; set; }
        [Required(ErrorMessage = "O Campo nome é obrigatório")]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } 
        public DateTime DataAlteracao { get; set; }

        public List<Produtos> Produtos { get; set; }
    }
}