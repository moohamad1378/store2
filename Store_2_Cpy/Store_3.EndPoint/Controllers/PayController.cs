using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Store_2.Application.Payments;
using Store_2.Domain.Payments;
using Store_3.EndPoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinPal.Class;

namespace Store_3.EndPoint.Controllers
{
    public class PayController : Controller
    {
        private readonly ZarinPal.Class.Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;

        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;
        private readonly string merchendid;

        public PayController(IConfiguration configuration, IPaymentService paymentService)
        {
            _configuration = configuration;
            _paymentService = paymentService;
            merchendid = configuration["ZarinPalMerchendId"];

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(Guid Paymentid)
        {
            var payment = _paymentService.GetPayment(Paymentid);
            if (payment == null)
            {
                return NotFound();
            }
            string userid = ClaimUtility.GetUserId(User);
            if (userid != payment.Userid)
            {
                return BadRequest();
            }
            string callbackurl = Url.Action(nameof(Verify), "Pay", new { payment.Id }, protocol: Request.Scheme);
            var resultZarinPalRequest = await _payment.Request(new DtoRequest()
            {
                Amount = payment.Amount,
                CallbackUrl = callbackurl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Mobile = payment.PhoneNumber
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinPalRequest.Authority}");
        }
        public IActionResult Verify(Guid id, string Authority)
        {
            string status = HttpContext.Request.Query["Status"];
            if (status != "" && status.ToString().ToLower() == "ok" && Authority != "") ;
            {
                var payment = _paymentService.GetPayment(id);
                if (payment == null)
                {
                    return NotFound();
                }
                //var verification= _payment.Verification(new DtoVerification
                //{
                //    Amount = payment.Amount,
                //    Authority = Authority,
                //    MerchantId = merchendid,
                //}, Payment.Mode.sandbox).Result;
                var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", $"{{\"MerchantId\" :\"{merchendid}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                var respons = client.Execute(request);
                VerificationPayResultDto verification =
                    JsonConvert.DeserializeObject<VerificationPayResultDto>(respons.Content);

                if (verification.Status == 100)
                {
                    bool verifyresult = _paymentService.VerifyPayment(id, Authority, verification.RefId);
                    if (verifyresult)
                    {
                        return Redirect("Customers/Orders");
                    }
                    else
                    {
                        TempData["message"] = "The pay was Successfully but did not registered";
                        return RedirectToAction("checkout", "basket");
                    }
                    //business cods
                }
                else
                {
                    TempData["message"] = "The pay was faild try again";
                    return RedirectToAction("checkout", "basket");
                }
            }
            TempData["message"] = "_The pay was faild_ ";
            return RedirectToAction("checkout", "basket");
        }
    }
    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefId { get; set; }
    }
}

