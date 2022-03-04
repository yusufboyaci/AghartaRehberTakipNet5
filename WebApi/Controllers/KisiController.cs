using DataAccess.Abstract;
using DataAccess.Enums;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : Controller
    {
        private readonly IKisiRepository _kisiRepository;
        public KisiController(IKisiRepository kisiRepository)
        {
            _kisiRepository = kisiRepository;
        }
        [HttpGet]
        public IActionResult GetirKisiler()
        {

            return Json(_kisiRepository.Kisiler.Where(x => x.IsActive == true));
        }
        [HttpGet("{id}")]
        public IActionResult GetirKisiIdIle(int id)
        {
            return Json(_kisiRepository.GetirKisiIdIle(id));
        }
        [HttpPost]
        public IActionResult KisiEkle(Kisi kisi)
        {
            _kisiRepository.KisiEkle(kisi);
            return Ok();
        }
        [HttpPut]
        public IActionResult KisiGuncelle(Kisi kisi)
        {
            //if (StatusEnum.Success == 0)
            //{

            //}
            _kisiRepository.KisiGuncelle(kisi);
            return Ok();
        }

        //[HttpDelete("{id}")]
        //public IActionResult KisiSil(int id)
        //{
        //    _kisiRepository.KisiSil(id);
        //    return Ok();
        //}
        [HttpDelete("{id}")]
        public IActionResult KisiSil(int id)
        {
            try
            {
                Kisi kisi = _kisiRepository.GetirKisiIdIle(id);
                kisi.IsActive = false;
                _kisiRepository.KisiGuncelle(kisi);
                return Ok();
            }
            catch (Exception m)
            {

                throw new Exception(m.Message);
            }
           
            
        }
    }
}
