using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Domain;
using Amazon.Core.DomainObjects.DTO;

namespace Amazon.Compras.Application.Services
{
    public class CompraService : ICompraService
    {
        private ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<DadosCompraViewModel> ObterDadosCompra(int idCompra)
        {
            DadosCompraViewModel retorno = null;
            var compra = await _compraRepository.ObterDadosCompra(idCompra);

            if (compra != null)
            {
                retorno = new DadosCompraViewModel()
                {
                    ItensCompra = MappingCompraProdutoParaItensCompra(compra.CompraProduto.ToList())
                    
                };
                retorno.ValorTotal = retorno.ItensCompra.Sum(x => x.ValorProduto);
            }
            return retorno;
        }

        private List<CompraProdutoViewModel> MappingCompraProdutoParaItensCompra(List<CompraProduto> compraProduto)
        {
            var retorno = new List<CompraProdutoViewModel>();

            foreach(var produto in compraProduto)
            {
                retorno.Add(new CompraProdutoViewModel()
                {
                    NomeProduto = "XPTO",
                    ValorProduto = 10.0M
                });
            }
            return retorno;
        }
    }
}
