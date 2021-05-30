using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI.Viewers
{
    public class EffectIcon : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private GameObject _lv;
        [SerializeField]
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _lv.SetActive(false);
        }

        public void Init(BaseData data)
        {
            var lv = data.Name.Substring(data.Name.Length - 1);
            _icon.sprite = data.Image;
            if (int.TryParse(lv, out _))
            {
                _text.text = lv;
                _lv.SetActive(true);
            }
        }
    }
}