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
        private List<MaterialAndQuantity> _needMaterials;
        [SerializeField]
        private ItemData _product;

        public IEnumerable<MaterialAndQuantity> NeedMaterials{ get { return _needMaterials; } }
        public ItemData Product{ get { return _product; } }

        public new void Copy(RecipeData data)
        {
            base.Copy(data);
            _needMaterials = data.NeedMaterials as List<MaterialAndQuantity>;
            _product = data.Product;
        }
    }
}