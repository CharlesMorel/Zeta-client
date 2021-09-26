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
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth:true, receiveData:true)
                .GetAsync($"{ApiRequestHelper.GetEntityUrl(typeof(T))}{Id}");
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<List<T>> Get()
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true, receiveData: true).GetAsync(ApiRequestHelper.GetEntityUrl(typeof(T)));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(responseContent);
        }

        public async Task Insert(T entity)
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true).PostAsJsonAsync(ApiRequestHelper.GetEntityUrl(typeof(T)), entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
        }

        public async Task Insert(List<T> entities)
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true).PostAsJsonAsync(ApiRequestHelper.GetEntityUrl(typeof(T)), entities);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
        }

        public async Task Update(T entity)
        {
            // add boolean "many" parameter to target another PUT controller
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true).PutAsJsonAsync($"{ApiRequestHelper.GetEntityUrl(typeof(T))}true/", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
        }

        public async Task Delete(string id)
        {
            HttpResponseMessage response = await ApiRequestHelper.GetHttpClient(requireAuth: true).DeleteAsync($"{ApiRequestHelper.GetEntityUrl(typeof(T))}{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"La requête n'a pas abouti (code : {response.StatusCode}");
            }
        }
    }
}
