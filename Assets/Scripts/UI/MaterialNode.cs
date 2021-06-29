using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using TMPro;
using UniRx;
using Adv;
using Alchemy;
using UI.Orders;

namespace UI
{
    public class MaterialNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _requiredAndSelectedNum;

        private MaterialAndQuantity _materialAndQuantity;
        private List<ItemData> _selectedMaterials = new List<ItemData>();

        public int NeedQuantity { get { return _materialAndQuantity.Quantity; } }
        public IEnumerable<ItemData> SelectedMaterials { get { return _selectedMaterials; } }

        public void Init(MaterialAndQuantity materialAndQuantity)
        {
            _materialAndQuantity = materialAndQuantity;
            _image.sprite = materialAndQuantity.Material.Image;
            _requiredAndSelectedNum.text = "0/" + materialAndQuantity.Quantity;
        }

        public void SelectClear()
        {
            _selectedMaterials.Clear();
            _requiredAndSelectedNum.text = "0/" + _materialAndQuantity.Quantity;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var vOrder = Resources.Load("Datas/Order/ItemViewerOrder") as ItemViewerOrder;
            var sOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
            vOrder.WhiteList.Add(_materialAndQuantity.Material.ID);
            sOrder.Selectable.min = _materialAndQuantity.Quantity;
            sOrder.Selectable.max = _materialAndQuantity.Quantity;
            sOrder.Results.Clear();
            sOrder.Results.AddRange(_selectedMaterials);
            sOrder.OnOrderComplete.AddListener(() =>
            {
                _selectedMaterials.Clear();
                _selectedMaterials.AddRange(sOrder.Results.Cast<ItemData>());
                _requiredAndSelectedNum.text = _selectedMaterials.Count + "/" + _materialAndQuantity.Quantity;
                Resources.UnloadAsset(sOrder);
            });
            sOrder.OnOrderUnComplete.AddListener(() => 
            {
                Resources.UnloadAsset(sOrder);
            });
            MultiSceneManager.LoadScene("ItemSelect", () =>
            {
                Resources.UnloadAsset(vOrder);
            });
        }
    }
}