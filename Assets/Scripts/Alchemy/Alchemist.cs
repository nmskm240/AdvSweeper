using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MultiSceneManagement;
using Adv;
using UI;
using UI.Viewers;

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
        [SerializeField]
        private SelectorOrder _sOrder;
        [SerializeField]
        private ViewerOrder _vOrder;

        private List<MaterialNode> _materialNodes = new List<MaterialNode>();
        private bool _canAlchemy = true;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
            var recipe = Resources.Load("Datas/Recipe/" + _selectRecipeData.ID) as RecipeData;
            foreach (var materialAndQuantity in recipe.NeedMaterials)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<MaterialNode>();
                obj.transform.SetParent(_materials);
                obj.transform.localScale = Vector3.one;
                node.Init(materialAndQuantity);
                _materialNodes.Add(node);
            }
            _jar.SetRecipe(recipe);
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
            StartCoroutine(AlchemyProcess());
        }

        private IEnumerator AlchemyProcess()
        {
            var useMaterials = new List<ItemData>();
            var candidateCharacteristics = new List<CharacteristicsData>();
            foreach (var materialNode in _materialNodes)
            {
                var selectedMaterials = materialNode.SelectedMaterials;
                useMaterials.AddRange(selectedMaterials);
                foreach(var characteristics in selectedMaterials.Select(m => m.Characteristics))
                {
                    candidateCharacteristics.AddRange(characteristics);
                }
                materialNode.SelectClear();
            }
            var fixCharacteristics = candidateCharacteristics.Select(c => c.ID);
            _vOrder.WhiteList.AddRange(fixCharacteristics.Distinct());
            _sOrder.MinNumberOfSelectable = 0;
            _sOrder.MaxNumberOfSelectable = 3;
            var item = _jar.Alchemy(useMaterials);
            MultiSceneManager.LoadScene("CharacteristicSelect");
            yield return new WaitWhile(() => MultiSceneManager.IsLoaded("CharacteristicSelect"));
            item.Init(_sOrder.Results.Cast<CharacteristicsData>());
            GetItem(item);
            _vOrder.Reset();
            _sOrder.Reset();
        }
    }
}