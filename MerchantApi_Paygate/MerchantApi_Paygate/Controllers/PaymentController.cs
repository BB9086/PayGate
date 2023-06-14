using MerchantApi_Paygate.Models;
using MerchantApi_Paygate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantApi_Paygate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _payment;
        public PaymentController(IPayment payment)
        {
            _payment = payment;

        }
        [HttpPost(Name = nameof(AddNewCard))]

        public async Task<IActionResult> AddNewCard([FromBody] NewCard model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(err => err.Errors[0].ErrorMessage));
                }

                CardPaymentResponse response = await _payment.AddNewCard(model);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { error = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("{vaultId}", Name = nameof(GetVaultedCard))]
        public async Task<IActionResult> GetVaultedCard([FromRoute] string vaultId)
        {
            try
            {
                JToken result = await _payment.GetVaultedCard(vaultId);
                return Ok(result?.ToString());
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { error = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("query/{payRequestId}", Name = nameof(QueryTransaction))]
        public async Task<IActionResult> QueryTransaction([FromRoute] string payRequestId)
        {
            var pp = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(this.Request);
            var ppappa = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(this.Request);
           
            var x = HttpContext.Request.Path;
            var y = HttpContext.Request.Host;
            var mmm = HttpContext.Request.Headers;
            try
            {
                JToken result = await _payment.QueryTransaction(payRequestId);
                return Ok(result?.ToString());
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { error = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
