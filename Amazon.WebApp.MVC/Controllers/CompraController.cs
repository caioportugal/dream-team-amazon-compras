using System.Threading.Tasks;
using Amazon.Compras.Application.Queries.ViewModels;
using Amazon.Compras.Application.Services;
using Amazon.Purchases.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.WebApp.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IShippingService _shippingService;
        private readonly IWishService _wishService;
        public CompraController(IPurchaseService purchaseService,
                                IShippingService shippingService,
                                IWishService wishService)
        {
            _purchaseService = purchaseService;
            _shippingService = shippingService;
            _wishService = wishService;

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
            var success = await _wishService.AddWish(wishesViewModel);
            if (success)
                return Ok(success);
            return NotFound();
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
