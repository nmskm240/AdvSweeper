using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using MultiSceneManagement;
using Alchemy;

namespace UI
{    
    public class RecipeNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private RecipeData _out;
        [SerializeField]
        private RecipeData _base;

        private void Awake()
        {
            _image.sprite = _base.Product.Image;
            _name.text = _base.Product.Name;
        }

        public void Init(RecipeData recipe)
        {
            _base = recipe;
            _image.sprite = recipe.Product.Image;
            _name.text = recipe.Product.Name;
        }

        public void OnPointerClick(PointerEventData e)
        {
            _out.Copy(_base);
            MultiSceneManager.LoadScene("AlchemyMain");
        }
    }
}