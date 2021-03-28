using Amazon.Purchases.ErrorHandle;
using Amazon.Purchases.Resources.Response;
using Amazon.Purchases.Services;
using Amazon.Purchases.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Amazon.Purchases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : Controller
    {
        private readonly IWishService _wishService;
        public WishController(IWishService wishService)
        {
            _wishService = wishService;
        }

        [HttpPost]
        public ActionResult AddItemsInWishList(WishRequest wishRequest)
        {
            try
            {
                var wishResponse = _wishService.AddWish(wishRequest);
                return CreatedAtAction(nameof(Get), new { id = wishResponse.Id }, wishResponse);
            }
            catch (ItemNotFoundException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { e.Message, e.StackTrace });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<WishResponse> Get(int id)
        {
            try
            {
                var wish = _wishService.GetWish(id);
                return Ok(wish);
            }
            catch (ItemNotFoundException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { e.Message, e.StackTrace });
            }
        }
    }
}
