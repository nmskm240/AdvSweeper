using System.Collections.Generic;
using Adv;

namespace Alchemy
{
    public class Jar
    {
        public ItemData Alchemy(RecipeData recipe, IEnumerable<ItemData> materials)
        {
            return recipe.Product;
        }
    }
}