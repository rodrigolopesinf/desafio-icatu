using MediatR;
using SistemaCompra.Application.DTOs;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public List<ItemDTO> Itens { get; set; }
        public int Condicao {  get; set; }
    }
}
