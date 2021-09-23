using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaClient.Entities
{
    public class ModelIngredient: AbstractEntity
    {
        public float Grammage { get; set; }
        public FrisbeeModel FrisbeeModel { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
