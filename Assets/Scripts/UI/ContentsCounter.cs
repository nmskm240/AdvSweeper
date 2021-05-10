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
        private TextMeshProUGUI _count;

        public void Init(Sprite image, int count)
        {
            _image.sprite = image;
            _count.text = "x" + count.ToString();
        }
    }
}