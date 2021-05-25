using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace UI.Sliders
{    
    public class CycleSlider : MonoBehaviour 
    {
        [SerializeField, MinMaxRange(0.08f,0.92f)]
        private MinMax _range;
        [SerializeField]
        private TextMeshProUGUI _value;
        [SerializeField]
        private Image _back;
        [SerializeField]
        private Image _fill;
        [SerializeField]
        private Color[] _colors;

        private float _scale;

        public int Value
        { 
            get{ return int.Parse(_value.text); } 
            set
            {
                _value.text = value.ToString();
                _back.color = _colors[value / 100];
                _fill.color = _colors[(value / 100) + 1];
                _fill.DOFillAmount(_range.min + (_scale * value), 0.25f);
            }
        }

        private void Awake()
        {
            _scale = (_range.max - _range.min) / 100f;
        }
    }
}