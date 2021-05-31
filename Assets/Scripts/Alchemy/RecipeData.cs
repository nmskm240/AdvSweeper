using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace Alchemy
{    
    [CreateAssetMenu(fileName = "RecipeData", menuName = "AdvSweeper/RecipeData", order = 0)]
    public class RecipeData : BaseData 
    {
        [SerializeField]
        private Synthesizer<MaterialAndQuantity, ItemData> _recipe = new Synthesizer<MaterialAndQuantity, ItemData>();

        public IEnumerable<MaterialAndQuantity> NeedMaterials{ get { return _recipe.Materials; } }
        public ItemData Product{ get { return _recipe.Product; } }
    }
}