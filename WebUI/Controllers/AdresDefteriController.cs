using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ApiServices;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdresDefteriController : Controller
    {
        private readonly AdresDefteriApiService _service;
        private readonly KisiApiService _kisiService;
        public AdresDefteriController(AdresDefteriApiService service, KisiApiService kisiService)
        {
            _service = service;
            _kisiService = kisiService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.KisiListesi = await _kisiService.GetirKisiler();
            return View(await _service.GetirAdresDefterleri());
        }
        [HttpGet]
        public async Task<IActionResult> Create() {

            ViewBag.KisiListesi = await _kisiService.GetirKisiler();
            return View(); 
        
        
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdresDefteriVM adresDefteriVM)
        {
            adresDefteriVM.IsActive = true;
            await _service.AdresDefteriEkle(adresDefteriVM);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {

            ViewBag.KisiListesi = await _kisiService.GetirKisiler();

            return View(await _service.GetirAdresDefteriIdIle(id)); 
        
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdresDefteriVM adresDefteriVM)
        {
            adresDefteriVM.IsActive = true;
            await _service.AdresDefteriGuncelle(adresDefteriVM);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
