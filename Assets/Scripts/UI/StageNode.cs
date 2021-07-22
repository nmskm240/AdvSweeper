using UnityEngine;
using TMPro;
using Adv;
using UI.Orders;

namespace UI
{    
    public class StageNode : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public StageData Data;

        private void Awake() 
        {
            _text.text = Data.Name;
        }
    }
}