using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week11Day4.Services;
using WorldlineLiveServiceReference;

namespace Week11Day4.Controllers
{
    public class BankInfoController : Controller
    {
        private readonly IBankInfoService _bankInfoService;

        public BankInfoController(IBankInfoService bankInfoService)
        {
            _bankInfoService = bankInfoService;
        }

        // GET: BankInfoController
        public async Task<ActionResult> IndexAsync()
        {
            var bankDetails = await _bankInfoService.GetByIfscAsync("ICIC0000011");

            return View(bankDetails);
        }
    }
}
