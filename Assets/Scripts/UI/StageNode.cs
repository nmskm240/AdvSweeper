using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using Adv;
using UI.Orders;

namespace UI
{    
    public class StageNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private StageData _base;

        private void Awake() 
        {
            _text.text = _base.Name;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var order = Resources.Load("Datas/Order/LoadStageOrder") as LoadStageOrder;
            order.Data = _base;
            MultiSceneManager.LoadScene("BringItemSelect");
        }
    }
}