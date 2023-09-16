using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewlModels;

public class Produtos
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Status { get; set; }
    public int  QuantidadeEmEstoque { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}
