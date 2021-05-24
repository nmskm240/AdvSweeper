using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Adv;

namespace UI
{    
    public class ItemInfoViewer : MonoBehaviour 
    {
        [SerializeField]
        private ItemData _order;
        [SerializeField]
        private TextMeshProUGUI _itemName;
        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private SliderParameter _itemQuality;
        [SerializeField]
        private Transform _effectIcons;
        [SerializeField]
        private Transform _characteristicIcons;

        private void Awake()
        {
            _itemName.text = _order.Name;
            _itemImage.sprite = _order.Image;
            _itemQuality.Value = _order.Quality;
        }
    }
}