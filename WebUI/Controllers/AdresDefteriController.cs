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
        public AdresDefteriController(AdresDefteriApiService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetirAdresDefterleri());
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(AdresDefteriVM adresDefteriVM)
        {
            await _service.AdresDefteriEkle(adresDefteriVM);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) => View(await _service.GetirAdresDefteriIdIle(id));
        [HttpPost]
        public async Task<IActionResult> Edit(AdresDefteriVM adresDefteriVM)
        {
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
