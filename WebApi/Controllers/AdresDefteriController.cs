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
        //[HttpGet("GetirAdresDefteriler")]//HttpGet in yanına parentez açıp birşey yazma. [HttpGet] şeklinde yaz.
        [HttpGet]
        public IActionResult GetirAdresDefteriler()
        {
            return Json(_adresRepository.AdresDefteriler.Where(x => x.IsActive == true));
        }
        [HttpGet("{id}")]
        public IActionResult GetirAdresDefteriIdIle(int id)
        {
            return Json(_adresRepository.GetirAdresDefteriIdIle(id));
        }
        [HttpPost]
        public IActionResult AdresDefteriEkle(AdresDefteri adresDefteri)
        {
          bool durum =  _adresRepository.AdresDefteriEkle(adresDefteri);
            return Ok();
        }
        [HttpPut]
        public IActionResult AdresDefteriGuncelle(AdresDefteri adresDefteri)
        {
            _adresRepository.AdresDefteriGuncelle(adresDefteri);
            return Ok();
        }
        //[HttpDelete("{id}")]
        //public IActionResult AdresDefteriSil(int id)
        //{
        //    _adresRepository.AdresDefteriSil(id);
        //      return Ok();
        //}
        [HttpDelete("{id}")]
        //[HttpDelete("AdresDefteritSil/{id}")]
        public IActionResult AdresDefteritSil(int id)
        {
            AdresDefteri adresDefteri = _adresRepository.GetirAdresDefteriIdIle(id);
            adresDefteri.IsActive = false;
            adresDefteri.KisiId = 5;
            _adresRepository.AdresDefteriGuncelle(adresDefteri);
            return Ok();
        }
    }
}
