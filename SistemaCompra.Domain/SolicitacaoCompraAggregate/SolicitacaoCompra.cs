using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }

        [NotMapped]
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set;}

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, int condicaoPagamento)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            CondicaoPagamento = AlterarCondicaoPagamento(condicaoPagamento);
        }

        public void AdicionarItem(Item item)
        {
            Inicializar();                        
            Itens.Add(item);
            TotalGeral = TotalGeral.Add(new Money(item.Subtotal.Value));
        }

        public void RegistrarCompra()
        {
            if (Itens == null) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            if (TotalGeral.Value > 50000)
                CondicaoPagamento = AlterarCondicaoPagamento(30);
        }

        private void Inicializar()
        {
            if (Itens == null)
                Itens = new List<Item>();

            if (TotalGeral == null)
                TotalGeral = new Money();
        }

        public CondicaoPagamento AlterarCondicaoPagamento(int valor)
        {
           return new CondicaoPagamento(valor);
        }

    }
}
