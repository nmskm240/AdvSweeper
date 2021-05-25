using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using TMPro;
using Adv;
using Alchemy;
using UI.Viewers;

namespace UI
{    
    public class MaterialNode : MonoBehaviour, IPointerClickHandler 
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _requiredAndSelectedNum;
        [SerializeField]
        private ItemCollection _selectMaterials;
        [SerializeField]
        private ItemSelectOrder _order;

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
            _order.IDs.Add(_materialAndQuantity.Material.ID);
            _order.SelectNum = _materialAndQuantity.Quantity;
            _selectMaterials.Contents = _selectedMaterials;
            MultiSceneManager.LoadScene("MaterialSelect");
            StartCoroutine(WaitSelect());
        }

        private IEnumerator WaitSelect()
        {
            yield return new WaitWhile(() => MultiSceneManager.IsLoaded("MaterialSelect"));
            _selectedMaterials = new List<ItemData>(_selectMaterials.Contents);
            _requiredAndSelectedNum.text = _selectedMaterials.Count + "/" + _materialAndQuantity.Quantity;
            _selectMaterials.Contents.Clear();
            _order.Reset();
        }
    }
}