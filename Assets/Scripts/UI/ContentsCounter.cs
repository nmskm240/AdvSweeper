using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{    
    public class ContentsCounter : MonoBehaviour 
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _value;

        public int Value
        { 
            get{ return int.Parse(_value.text); } 
            set{ _value.text = (0 < value ? value : 0).ToString(); } 
        }

        public void Init(Sprite image, int value, bool operand = false, Color? color = null)
        {
            _image.sprite = image;
            _value.text = ((operand) ? "x" : "") + value.ToString();
            _value.color = color ?? Color.black;
        }
    }
}