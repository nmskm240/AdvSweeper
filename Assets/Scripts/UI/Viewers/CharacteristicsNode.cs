using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace UI.Viewers
{    
    public class CharacteristicsNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _info;

        private BaseData _data;

        public void Init(BaseData data)
        {
            _data = data;
            _image.sprite = data.Image;
            _name.text = data.Name;
            _info.text = data.Info;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var selectorOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
            if(selectorOrder.Results.Contains(_data, new ObjectCompare<Object>()))
            {
                _image.color = Color.white;
                selectorOrder.Results.Remove(_data);
            }
            else
            {
                _image.color = Color.gray;
                selectorOrder.Results.Add(_data);
            }
        }
    }
}