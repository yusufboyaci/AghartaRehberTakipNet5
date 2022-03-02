using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ApiServices;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class KisiController : Controller
    {
        private readonly KisiApiService _service;
        public KisiController(KisiApiService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetirKisiler());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(KisiVM kisiVM)
        {
            kisiVM.IsActive = true;
            await _service.KisiEkle(kisiVM);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) => View(_service.GetirKisiIdIle(id).Result);
        [HttpPost]
        public async Task<IActionResult> Edit(KisiVM kisiVM)
        {
            kisiVM.IsActive = true;
            await _service.KisiGuncelle(kisiVM);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
