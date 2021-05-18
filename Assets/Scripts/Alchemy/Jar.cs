using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adv;
using UI;

namespace Alchemy
{
    public class Jar : MonoBehaviour
    {
        [SerializeField]
        private Image _productImage;
        [SerializeField]
        private RecipeData _selectRecipeData;
        [SerializeField]
        private Transform _materials;
        [SerializeField]
        private ItemCollection _container;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
            _productImage.sprite = _selectRecipeData.Product.Image;
            foreach(var materialAndQuantity in _selectRecipeData.NeedMaterials)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<MaterialNode>();
                obj.transform.SetParent(_materials);
                obj.transform.localScale = Vector3.one;
                node.Init(materialAndQuantity);
            }
        }

        public void Alchemy()
        {
            _container.Contents.Add(_selectRecipeData.Product);
        }
    }
}