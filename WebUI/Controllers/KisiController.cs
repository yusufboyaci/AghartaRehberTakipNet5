using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(KisiVM kisiVM)
        {
            await _service.KisiEkle(kisiVM);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(KisiVM kisiVM,int id) => View(kisiVM);
        [HttpPost]
        public async Task<IActionResult> Edit(KisiVM kisiVM)
        {
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
