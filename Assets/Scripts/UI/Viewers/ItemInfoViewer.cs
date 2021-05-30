using System.Collections.Generic;
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

        private IFactory<GameObject> _factory = new EffectIconFactory();

        private void Start()
        {
            _itemName.text = _order.Name;
            _itemImage.sprite = _order.Image;
            _itemQuality.Value = _order.Quality;
            ShowIcons(_order.Effects, _effectIcons);
            ShowIcons(_order.Characteristics, _characteristicIcons);
        }

        private void ShowIcons(IEnumerable<BaseData> datas, Transform parent)
        {
            foreach(var data in datas)
            {
                var obj = _factory.Create();
                var node = obj.GetComponent<EffectIcon>();
                node.Init(data);
                obj.transform.SetParent(parent);
                obj.transform.localScale = Vector3.one;
            }
        }
    }
}