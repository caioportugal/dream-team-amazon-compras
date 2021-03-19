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
        private readonly IPurchaseService _purchaseService;
        private readonly IShippingService _shippingService;
        public CompraController(IPurchaseService purchaseService,
                                IShippingService shippingService)
        {
            _purchaseService = purchaseService;
            _shippingService = shippingService;

        }

        // GET api/compra/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseData(int id)
        {
            var purchaseData = await _purchaseService.GetPurchaseData(id);

            if (purchaseData != null)
                return Ok(purchaseData);
            return NotFound();
        }

        // POST api/compra/desejo
        [HttpPost]
        [Route("desejo")]
        public async Task<IActionResult> AddItemsInWishList([FromBody] WishesViewModel wishesViewModel)
        {
            return Ok("adicionado com sucesso");
        }

        // GET api/values
        [HttpGet("{id}/frete/{zipCode}")]
        public async Task<IActionResult> CalculateShippingValue(int id, string zipCode)
        {
            var shippingCalculation = await _shippingService.CalculateShipping(id, zipCode);
            if (shippingCalculation.Success)
                return Ok(shippingCalculation.ShippingValue);
            return NotFound(shippingCalculation.ErrorMessage);
        }
    }
}
