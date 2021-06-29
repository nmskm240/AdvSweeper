using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MultiSceneManagement;
using Adv;
using Adv.Effects;
using UI;
using UI.Orders;

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
            foreach (var materialNode in _materialNodes)
            {
                _canAlchemy &= materialNode.NeedQuantity == materialNode.SelectedMaterials.Count();
            }
            _jar.SetCanAlchemy(_canAlchemy);
        }

        public void Alchemy()
        {
            var sOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
            var vOrder = Resources.Load("Datas/Order/ViewerOrder") as ViewerOrder;
            var iOrder = Resources.Load("Datas/Order/ItemInfoViewerOrder") as ItemInfoViewerOrder;
            var useMaterials = new List<ItemData>();
            var candidateCharacteristics = new List<CharacteristicsData>();
            foreach (var materialNode in _materialNodes)
            {
                var selectedMaterials = materialNode.SelectedMaterials;
                useMaterials.AddRange(selectedMaterials);
                foreach (var characteristics in selectedMaterials.Select(m => m.Characteristics))
                {
                    candidateCharacteristics.AddRange(characteristics);
                }
                materialNode.SelectClear();
            }
            var fixCharacteristics = candidateCharacteristics.Select(c => c.ID);
            vOrder.WhiteList.AddRange(fixCharacteristics.Distinct());
            sOrder.Selectable.min = 0;
            sOrder.Selectable.max = 3;
            var item = _jar.Alchemy(useMaterials);
            Resources.UnloadAsset(vOrder);
            sOrder.Reset();
            sOrder.OnOrderComplete.AddListener(() =>
            {
                item.Init(sOrder.Results.Cast<CharacteristicsData>());
                foreach (var characteristic in item.Characteristics)
                {
                    if (characteristic.Timing == EffectTiming.Init)
                    {
                        characteristic.Effect.Activate(item);
                    }
                }
                GetItem(item);
                iOrder.Data = item;
                MultiSceneManager.LoadScene("ItemInfo", () =>
                {
                    Resources.UnloadAsset(sOrder);
                    Resources.UnloadAsset(iOrder);
                });
            });
            MultiSceneManager.LoadScene("CharacteristicSelect");

        }
    }
}