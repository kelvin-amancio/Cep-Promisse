using CepPromisse.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CepPromisse.Web.Controllers
{
    public class CepController : Controller
    {
        private readonly ICepService _cepService;
        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetZipCode(string? cep)
        {
            var response = await _cepService.GetByCep(cep!);

            if(response.StatusCode == HttpStatusCode.OK)
                return View(response.Response);

            return StatusCode((int)response.StatusCode, response.Error);
        }

        public IActionResult Modal()
        {
            return PartialView("_Modal");
        }
    }
}
