using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresDefteriController : Controller
    {
        private readonly IAdresRepository _adresRepository;
        public AdresDefteriController(IAdresRepository adresRepository)
        {
            _adresRepository = adresRepository;
        }
        [HttpGet]
        public IActionResult GetirAdresDefteriler()
        {
            var nesne = JsonConvert.SerializeObject(_adresRepository.AdresDefteriler);
            return Json(nesne);
        }
        [HttpGet("{id}")]
        public IActionResult GetirAdresDefteriIdIle(int id)
        {
            return Json(_adresRepository.GetirAdresDefteriIdIle(id));
        }
        [HttpPost]
        public IActionResult AdresDefteriEkle(AdresDefteri adresDefteri)
        {
            return Json(_adresRepository.AdresDefteriEkle(adresDefteri));
        }
        [HttpPut]
        public IActionResult AdresDefteriGuncelle(AdresDefteri adresDefteri)
        {
            return Json(_adresRepository.AdresDefteriGuncelle(adresDefteri));
        }
        [HttpDelete("{id}")]
        public IActionResult AdresDefteriSil(int id)
        {
            return Json(_adresRepository.AdresDefteriSil(id));
        }
    }
}
