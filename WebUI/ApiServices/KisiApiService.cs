using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ApiServices
{
    public class KisiApiService
    {

        private readonly HttpClient _httpClient;
        public KisiApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<KisiVM>> GetirKisiler()
        {
            IEnumerable<KisiVM> nesne;
            var response = await _httpClient.GetAsync("kisi");
            if (response.IsSuccessStatusCode)
            {
                nesne = JsonConvert.DeserializeObject<IEnumerable<KisiVM>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                nesne = null;
            }
            return nesne;
        }

        public async Task<KisiVM> GetirKisiIdIle(int id)
        {
            var response = await _httpClient.GetAsync($"kisi/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<KisiVM>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<KisiVM> KisiEkle(KisiVM kisiVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(kisiVM), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("kisi", content);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<KisiVM>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> KisiGuncelle(KisiVM kisiVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(kisiVM), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("kisi", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"kisi/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
