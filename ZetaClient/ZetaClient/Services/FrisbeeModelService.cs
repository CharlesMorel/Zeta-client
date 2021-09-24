using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.DataAccess;
using ZetaClient.Entities;
using ZetaClient.Services.Abstract;

namespace ZetaClient.Services
{
    public class FrisbeeModelService : AbstractService<FrisbeeModel>
    {
        private readonly ModelIngredientApiDao _modelIngredientDao;
        public FrisbeeModelService()
        {
            _modelIngredientDao = new ModelIngredientApiDao();
            Dao = new FrisbeeModelApiDao();
        }

        public async Task Create(FrisbeeModel entity, List<Ingredient> ingredients)
        {
            await Dao.Insert(entity);
            List<ModelIngredient> modelIngredients = new List<ModelIngredient>();
            ingredients.ForEach(ingredient =>
            {
                modelIngredients.Add(new ModelIngredient()
                {
                    Ingredient = ingredient,
                    FrisbeeModel = entity
                });
            });
            await _modelIngredientDao.Insert(modelIngredients);
        }

        public async Task<List<Ingredient>> GetIngredientByModel(string id)
        {
            List<ModelIngredient> allModelIngredients = await _modelIngredientDao.Get();
            List<ModelIngredient> modelIngredients = allModelIngredients.Where(modelIngredient => modelIngredient.FrisbeeModel.Id == id).ToList();
            List<Ingredient> ingredients = new List<Ingredient>();
            modelIngredients.ForEach(modelIngredient =>
            {
                ingredients.Add(modelIngredient.Ingredient);
            });
            return ingredients;
        }
    }
}
