using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Domain;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amazon.Compras.Application.Services
{
    public class FreteService : IFreteService
    {
        private ICompraRepository _compraRepository;

        public FreteService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<FreteViewModel> CalcularFreteAsync(int idCompra, string cep)
        {
            var freteViewModel = new FreteViewModel
            {
                Sucesso = false
            };
            var regexCep = new Regex(@"^([0-9]){8}$|^(([0-9]){5}(-)([0-9]){3})$");
            if (!regexCep.IsMatch(cep))
            {
                freteViewModel.MensagemErro = $"CEP {cep} inválido.";
                return freteViewModel;
            }
            var isCompraValida = await _compraRepository.ExisteCompraComID(idCompra);
            if (!isCompraValida)
            {
                freteViewModel.MensagemErro = $"Compra com ID: {idCompra} não existe.";
                return freteViewModel;
            }
            var doisUltimosCaracteres = Int32.Parse(cep.Substring(cep.Length - 2));
            freteViewModel.Sucesso = true;
            freteViewModel.ValorFrete = idCompra * doisUltimosCaracteres;
            return freteViewModel;

        }
    }
}
