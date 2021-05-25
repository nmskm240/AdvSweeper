using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Adv;
using UI.Sliders;

namespace UI.Viewers
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
        private CycleSlider _itemQuality;
        [SerializeField]
        private Transform _effectIcons;
        [SerializeField]
        private Transform _characteristicIcons;

        private void Start()
        {
            _itemName.text = _order.Name;
            _itemImage.sprite = _order.Image;
            _itemQuality.Value = _order.Quality;
        }
    }
}