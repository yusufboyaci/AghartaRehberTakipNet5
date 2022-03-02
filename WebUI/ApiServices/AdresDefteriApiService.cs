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
    public class AdresDefteriApiService
    {
        private readonly HttpClient _httpClient;
        public AdresDefteriApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<AdresDefteriVM>> GetirAdresDefterleri()
        {
            IEnumerable<AdresDefteriVM> nesne;
            var response = await _httpClient.GetAsync("adresdefteri");
            if (response.IsSuccessStatusCode)
            {
                nesne = JsonConvert.DeserializeObject<IEnumerable<AdresDefteriVM>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                nesne = null;
            }
            return nesne;
        }
        public async Task<AdresDefteriVM> GetirAdresDefteriIdIle(int id)
        {
            var response = await _httpClient.GetAsync($"AdresDefteri/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AdresDefteriVM>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
        public async Task<AdresDefteriVM> AdresDefteriEkle(AdresDefteriVM adresDefteriVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(adresDefteriVM), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AdresDefteri", content);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AdresDefteriVM>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AdresDefteriGuncelle(AdresDefteriVM adresDefteriVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(adresDefteriVM), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("AdresDefteri", content);
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
            var response = await _httpClient.DeleteAsync($"AdresDefteri/{id}");
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
