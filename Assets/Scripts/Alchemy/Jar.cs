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
        private Button _alchemyButton;

        private RecipeData _recipe;

        public void SetCanAlchemy(bool canAlchemy)
        {
            _alchemyButton.interactable = canAlchemy;
        }

        public void SetRecipe(RecipeData recipe)
        {
            _recipe = recipe;
            _productImage.sprite = _recipe.Product.Image;
        }

        public ItemData Alchemy(IEnumerable<ItemData> materials)
        {
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.RemoveItems(materials);
            return ScriptableObject.Instantiate(_recipe.Product);
        }
    }
}