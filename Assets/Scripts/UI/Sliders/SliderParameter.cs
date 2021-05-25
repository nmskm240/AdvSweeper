using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace UI.Sliders
{
    public class SliderParameter : MonoBehaviour
    {
        [SerializeField]
        private SliderParameterOptions _options = SliderParameterOptions.ValueNone;
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private TextMeshProUGUI _value;
        [SerializeField]
        private Slider _slider;

        public string Name{ get { return _text.text; } }
        public float Min{ get { return _slider.minValue; } }
        public float Max{ get { return _slider.maxValue; } }
        public float Value
        { 
            get { return _slider.value; } 
            set
            { 
                _slider.DOValue(value, 1f).OnComplete(() => 
                {
                    _value.text = (_options == SliderParameterOptions.ValueOnly) ? 
                        _slider.value.ToString() : _slider.value + "/" + Max;
                }); 
            } 
        }

        private void Awake()
        {
            _value.enabled = (_options != SliderParameterOptions.ValueNone);
        }

        public void Init(string name, int min, int max)
        {
            SetName(name);
            Range(min, max);
        }

        public void SetName(string name)
        {
            _text.text = name;
        }

        public void Range(int min, int max)
        {
            _slider.minValue = min;
            _slider.maxValue = max;
        }
    }
}