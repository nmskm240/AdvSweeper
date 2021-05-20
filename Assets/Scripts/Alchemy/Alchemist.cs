using System.Collections.Generic;
using UnityEngine;
using Adv;
using UI;

namespace Alchemy
{
    public class Alchemist : Player
    {
        [SerializeField]
        private Transform _materials;
        [SerializeField]
        private Jar _jar;
        [SerializeField]
        private RecipeData _selectRecipeData;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
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
            _container.Contents.Add(_jar.Alchemy());
        }
    }
}