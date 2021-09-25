using System;
using System.Collections.Generic;
using System.Linq;
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
            if (type == typeof(Session))
            {
                return $"{AppConstants.BaseApiUrl}sessions/";
            }
            if (type == typeof(User))
            {
                return $"{AppConstants.BaseApiUrl}users/";
            }

            return AppConstants.BaseApiUrl;
        }
    }
}
