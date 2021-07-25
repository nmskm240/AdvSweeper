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
        [SerializeField]
        private StageData _data;

        public StageData Data { get { return _data; } }

        private void Awake() 
        {
            _text.text = _data.Name;
        }
    }
}