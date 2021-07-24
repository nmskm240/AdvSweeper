using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adv;
using UI.Orders;

namespace Alchemy
{
    public class Jar : OrderReceiveMonoBehaviour<LoadRecipeOrder>
    {
        [SerializeField]
        private Image _productImage;
        [SerializeField]
        private Button _alchemyButton;

        public bool CanAlchemy 
        {
            get { return _alchemyButton.interactable; }
            set { _alchemyButton.interactable = value; }
        }

        private void Awake()
        {
            _productImage.sprite = _order.Data.Product.Image;
        }

        public ItemData Alchemy(IEnumerable<ItemData> materials)
        {
            var product = ScriptableObject.Instantiate(_order.Data.Product);
            var player = GameObject.Find("Player").GetComponent<Player>();
            product.Quality = materials.Select(item => item.Quality).Sum() / materials.Count();
            player.RemoveItems(materials);
            return product;
        }
    }
}