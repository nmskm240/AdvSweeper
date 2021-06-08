using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Adv;
using UI.Sliders;

namespace UI.Viewers
{    
    public class ItemInfoViewer : Viewer<ItemInfoViewerOrder>
    {
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

        public override void Show()
        {
            _itemName.text = _order.Data.Name;
            _itemImage.sprite = _order.Data.Image;
            _itemQuality.Value = _order.Data.Quality;
            ShowIcons(_order.Data.Effects, _effectIcons);
            ShowIcons(_order.Data.Characteristics, _characteristicIcons);
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