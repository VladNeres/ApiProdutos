﻿using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.SeviceInterfaces
{
    public interface IProdutoService
    {
        Task<MensagemBase<List<Produto>>> BuscarPedidos();
        Task<MensagemBase<ReadProdutoDto>> BuscarPedidosPorId(int id);
        Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoDto>> AtualizarPedido(int id, UpdateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoSimplificado>> AtualizarPedidoSimplificado(int id, UpdateProdutoSimplificado produtoDto);
        Task<MensagemBase<bool>> DeletarProduto(int id);



    }
}