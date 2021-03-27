using Amazon.Purchases.ErrorHandle;
using Amazon.Purchases.Services;
using Amazon.Purchases.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Amazon.Purchases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IShippingService _shippingService;
        
        public PurchaseController(IPurchaseService purchaseService,
                                IShippingService shippingService)
        {
            _purchaseService = purchaseService;
            _shippingService = shippingService;         
        }

        [HttpPost]
        public ActionResult CreatePurchase(PurchaseRequest purchase)
        {
            try
            {
                var purchaseResponse = _purchaseService.AddPurchase(purchase);
                return CreatedAtAction(nameof(GetPurchaseData),
                                      new { id = purchaseResponse.PurchaseId },
                                      purchaseResponse);
            }
            catch (ProductNotFoundException pe)
            {
                return StatusCode((int)HttpStatusCode.NotFound, pe.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<PurchaseResponse> GetPurchaseData(int id)
        {
            try
            {
                var purchaseData = _purchaseService.GetPurchaseData(id);
                if (purchaseData == null)
                    return NotFound();
                return Ok(purchaseData);
            }
            catch (ProductNotFoundException pe)
            {
                return StatusCode((int)HttpStatusCode.NotFound, pe.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { e.Message, e.StackTrace });
            }
        }      

        [HttpGet("{id}/frete/{zipCode}")]
        public ActionResult<ShippingResponse> CalculateShippingValue(int id, string zipCode)
        {
            var shippingCalculation = _shippingService.CalculateShipping(id, zipCode);
            if (shippingCalculation.Success)
                return Ok(shippingCalculation);
            return NotFound(shippingCalculation);
        }
    }
}
