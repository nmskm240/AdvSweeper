using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace Alchemy
{    
    [CreateAssetMenu(fileName = "RecipeData", menuName = "AdvSweeper/RecipeData", order = 0)]
    public class RecipeData : ScriptableObject 
    {
        [SerializeField]
        private List<MaterialAndQuantity> _needMaterials;
        [SerializeField]
        private ItemData _product;

        public IEnumerable<MaterialAndQuantity> NeedMaterials{ get { return _needMaterials; } }
        public ItemData Product{ get { return _product; } }
    }
}