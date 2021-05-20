using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adv;

namespace Alchemy
{
    public class Jar : MonoBehaviour
    {
        [SerializeField]
        private Image _productImage;
        [SerializeField]
        private RecipeData _selectRecipeData;

        private void Awake() 
        {
            _productImage.sprite = _selectRecipeData.Product.Image;
        }

        public ItemData Alchemy(IEnumerable<ItemData> materials)
        {
            var player = GameObject.Find("Player").GetComponent<Alchemist>();
            player.RemoveItems(materials);
            return _selectRecipeData.Product;
        }
    }
}