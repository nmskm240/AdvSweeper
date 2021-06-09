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
        [SerializeField]
        private ViewerOrder _viewerOrder;        
        [SerializeField]
        private SelectorOrder _selectorOrder;

        private MaterialAndQuantity _materialAndQuantity;
        private List<ItemData> _selectedMaterials = new List<ItemData>();

        public int NeedQuantity{ get { return _materialAndQuantity.Quantity;} }
        public IEnumerable<ItemData> SelectedMaterials{ get { return _selectedMaterials; } }

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
            _viewerOrder.WhiteList.Add(_materialAndQuantity.Material.ID);
            _selectorOrder.MinNumberOfSelectable = _materialAndQuantity.Quantity;
            _selectorOrder.MaxNumberOfSelectable = _materialAndQuantity.Quantity;
            _selectorOrder.Results.Clear();
            _selectorOrder.Results.AddRange(_selectedMaterials);
            MultiSceneManager.LoadScene("ItemSelect");
            StartCoroutine(WaitSelect());
        }

        private IEnumerator WaitSelect()
        {
            yield return new WaitWhile(() => MultiSceneManager.IsLoaded("ItemSelect"));
            _selectedMaterials.Clear();
            _selectedMaterials.AddRange(_selectorOrder.Results.Cast<ItemData>());
            _requiredAndSelectedNum.text = _selectedMaterials.Count + "/" + _materialAndQuantity.Quantity;
            _viewerOrder.Reset();
            _selectorOrder.Reset();
        }
    }
}