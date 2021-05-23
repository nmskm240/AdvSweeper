using System.Collections.Generic;
using System.Linq;
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

        private List<MaterialNode> _materialNodes = new List<MaterialNode>();
        private bool _canAlchemy = true;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
            foreach (var materialAndQuantity in _selectRecipeData.NeedMaterials)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<MaterialNode>();
                obj.transform.SetParent(_materials);
                obj.transform.localScale = Vector3.one;
                node.Init(materialAndQuantity);
                _materialNodes.Add(node);
            }
            _jar.SetRecipe(_selectRecipeData);
        }

        private void Update()
        {
            _canAlchemy = true;
            foreach(var materialNode in _materialNodes)
            {
                _canAlchemy &= materialNode.NeedQuantity == materialNode.SelectedMaterials.Count();
            }
            _jar.SetCanAlchemy(_canAlchemy);
        }

        public void Alchemy()
        {
            var useMaterials = new List<ItemData>();
            foreach (var materialNode in _materialNodes)
            {
                useMaterials.AddRange(materialNode.SelectedMaterials);
                materialNode.SelectClear();
            }
            GetItem(_jar.Alchemy(useMaterials));
        }
    }
}