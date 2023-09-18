
using System.ComponentModel.DataAnnotations;
namespace ConnectionSql.Dtos;

public class CreateCategoriaDto
{
    [Required(ErrorMessage = "O Campo nome de categoria é obrigatório")]
    [RegularExpression(@"[a-zA-Zá-úÁ-Ú' '\s]{1,1000}", ErrorMessage = "O campo nome deve conter apenas letras")]
    [StringLength(50, ErrorMessage = "quantidade de caracteres exede o limite de 50")]
    public string Nome { get; set; }
   
}
