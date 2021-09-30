using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.Entities
{
    public class ModelIngredient: AbstractEntity
    {
        public double Grammage { get; set; }
        public FrisbeeModel Frisbee { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
