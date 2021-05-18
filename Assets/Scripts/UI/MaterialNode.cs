using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using TMPro;
using Adv;
using Alchemy;

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

        public IEnumerable<ItemData> SelectedMaterials{ get { return _selectedMaterials; } }

        public void Init(MaterialAndQuantity materialAndQuantity)
        {
            _materialAndQuantity = materialAndQuantity;
            _image.sprite = materialAndQuantity.Material.Image;
            _requiredAndSelectedNum.text = "0/" + materialAndQuantity.Quantity;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var order = Resources.Load("Datas/ItemViewerOrder") as ItemViewerDisplayOrder;
            order.IDs.Add(_materialAndQuantity.Material.ID);
            MultiSceneManager.LoadScene("MaterialSelect");
        }
    }
}