using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Constants;
using ZetaClient.Helpers;

namespace ZetaClient.Managers
{
    public static class ConnectionManager
    {
        public async static Task<Dictionary<string, object>> LogUserIn(string email, string password)
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(receiveData: true).PostAsJsonAsync($"{AppConstants.BaseApiUrl}auth/", new
            {
                Email = email,
                Password = password
            });
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
            
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(await response.Content.ReadAsStringAsync());
        }

        public async static Task LogOut()
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true).DeleteAsync($"{AppConstants.BaseApiUrl}auth/");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
        }
    }
}
