using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Alchemy;

namespace UI
{    
    public class RecipeNode : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private RecipeData _data;

        public RecipeData Data { get { return _data; } }

        private void Awake()
        {
            _image.sprite = _data.Product.Image;
            _name.text = _data.Product.Name;
        }
    }
}