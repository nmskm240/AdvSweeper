using UnityEngine;
using UnityEngine.UI;

namespace UI
{    
    public class ContentsCounter : MonoBehaviour 
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _count;

        public void Init(Sprite image, int count)
        {
            _image.sprite = image;
            _count.text = count.ToString();
        }
    }
}