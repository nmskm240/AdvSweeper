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
        private GameObject _materials;
        [SerializeField]
        private Jar _jar;

        private List<MaterialNode> _materialNodes = new List<MaterialNode>();

        private void Start() 
        {
            _materialNodes.AddRange(_materials.GetComponentsInChildren<MaterialNode>());
        }

        private void LastUpdate()
        {
            var canAlchemy = true;
            foreach (var materialNode in _materialNodes)
            {
                canAlchemy &= materialNode.NeedQuantity == materialNode.SelectedMaterials.Count();
            }
            _jar.CanAlchemy = canAlchemy;
        }

        public void Alchemy()
        {
            var sOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
            var vOrder = Resources.Load("Datas/Order/CharacteristicsViewerOrder") as CharacteristicsViewerOrder;
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
            vOrder.Contents.AddRange(fixCharacteristics.Distinct());
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