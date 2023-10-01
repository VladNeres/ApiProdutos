using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewlModels
{
    public class ProdutoType
    {
        public ProdutoType(string codigoDoPedido)
        {
            CodigoDoPedido = codigoDoPedido;
        }

        public ProdutoType(int iD, string nome, double valor, DateTime dataCriacao, DateTime dataAlteracao, bool status, int quantidadeEmEstoque, int categoriaId, Categoria categoria, string codigoDoPedido)
        {
            ID = iD;
            Nome = nome;
            Valor = valor;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            Status = status;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            CategoriaId = categoriaId;
            Categoria = categoria;
            CodigoDoPedido = codigoDoPedido;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        [JsonProperty("StatusPedido")]
        public bool Status { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string CodigoDoPedido { get; set; }
    }
}
