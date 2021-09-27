using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Constants;
using ZetaClient.Entities;

namespace ZetaClient.Helpers
{
    public static class ApiRequestHelper
    {
        public static string GetEntityUrl(Type type)
        {
            if (type == typeof(FrisbeeModel))
            {
                return $"{AppConstants.BaseApiUrl}models/";
            }
            if (type == typeof(Ingredient))
            {
                return $"{AppConstants.BaseApiUrl}ingredients/";
            }
            if (type == typeof(ModelIngredient))
            {
                return $"{AppConstants.BaseApiUrl}modelingredients/";
            }
            if (type == typeof(Process))
            {
                return $"{AppConstants.BaseApiUrl}process/";
            }
            if (type == typeof(User))
            {
                return $"{AppConstants.BaseApiUrl}users/";
            }

            return AppConstants.BaseApiUrl;
        }

        public static HttpClient GetHttpClient(bool requireAuth = true, bool receiveData = false)
        {
            HttpClient client = new HttpClient();
            
            if(requireAuth)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("ApiKey", AppConstants.ApiKey);
            }
            if(receiveData)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return client;
        }
    }
}
