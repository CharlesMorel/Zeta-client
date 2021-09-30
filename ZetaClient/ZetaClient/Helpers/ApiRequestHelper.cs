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
                return $"{AppConstants.BaseApiUrl}:8000/frisbees/";
            }
            if (type == typeof(Ingredient))
            {
                return $"{AppConstants.BaseApiUrl}:8002/ingredients/";
            }
            if (type == typeof(ModelIngredient))
            {
                return $"{AppConstants.BaseApiUrl}:8000/frisbee_ingredients/";
            }
            if (type == typeof(Process))
            {
                return $"{AppConstants.BaseApiUrl}:8001/process/";
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
