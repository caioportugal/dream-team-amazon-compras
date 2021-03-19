using System.Threading.Tasks;
using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.WebApp.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly ICompraService _compraService;
        private readonly IFreteService _freteService;
        public CompraController(ICompraService compraService,
                                IFreteService freteService)
        {
            _compraService = compraService;
            _freteService = freteService;

        }

        // GET api/compra/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDadosCompra(int id)
        {
            var dadosCompra = await _compraService.ObterDadosCompra(id);

            if (dadosCompra != null)
                return Ok(dadosCompra);
            return NotFound();
        }

        // POST api/compra/desejo
        [HttpPost]
        [Route("desejo")]
        public async Task<IActionResult> AdicionarListaDesejo([FromBody] DesejosViewModel desejoViewModel)
        {
            return Ok("adicionado com sucesso");
        }

        // GET api/values
        [HttpGet("{id}/frete/{cep}")]
        public async Task<IActionResult> CalcularFreteCompra(int id, string cep)
        {
            var calculoFrete = await _freteService.CalcularFreteAsync(id, cep);
            if (calculoFrete.Sucesso)
                return Ok(calculoFrete.ValorFrete);
            return NotFound(calculoFrete.MensagemErro);
        }
    }
}
