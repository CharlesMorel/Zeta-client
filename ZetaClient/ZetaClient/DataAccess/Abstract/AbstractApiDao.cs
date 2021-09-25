using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Constants;
using ZetaClient.Entities.Abstract;
using ZetaClient.Helpers;

namespace ZetaClient.DataAccess.Abstract
{
    public abstract class AbstractApiDao<T> : IDao<T> where T : class, IEntity
    {
        public async Task<T> Get(string Id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("ApiKey", AppConstants.ApiKey);
            client.DefaultRequestHeaders.TryAddWithoutValidation("IdSession", AppConstants.IdSession);

            HttpResponseMessage response = await client.GetAsync($"{ApiRequestHelper.GetEntityUrl(typeof(T))}{Id}");
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<List<T>> Get()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("ApiKey", AppConstants.ApiKey);
            client.DefaultRequestHeaders.TryAddWithoutValidation("IdSession", AppConstants.IdSession);

            HttpResponseMessage response = await client.GetAsync(ApiRequestHelper.GetEntityUrl(typeof(T)));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(responseContent);
        }

        public async Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            var test = typeof(T);
            throw new NotImplementedException();
        }
    }
}
