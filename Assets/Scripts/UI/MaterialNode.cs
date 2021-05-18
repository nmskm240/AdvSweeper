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
        private TextMeshProUGUI _needAndSelectedQuantity;

        public void Init(MaterialAndQuantity materialAndQuantity)
        {
            _image.sprite = materialAndQuantity.Material.Image;
            _needAndSelectedQuantity.text = "0/" + materialAndQuantity.Quantity;
        }

        public void OnPointerClick(PointerEventData e)
        {
            MultiSceneManager.LoadScene("MaterialSelect");
        }
    }
}