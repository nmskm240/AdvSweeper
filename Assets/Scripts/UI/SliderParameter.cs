using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderParameter : MonoBehaviour
    {
        [SerializeField]
        private Text _text;
        [SerializeField]
        private Slider _slider;

        public string Name{ get { return _text.text; } }
        public float Min{ get { return _slider.minValue; } }
        public float Max{ get { return _slider.maxValue; } }
        public float Value{ get { return _slider.value; } set { _slider.value = value; } }

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