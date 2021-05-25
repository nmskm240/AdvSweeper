using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI.Popups
{    
    public class Dialog : MonoBehaviour 
    {
        [SerializeField]
        private TextMeshProUGUI _body;
        [SerializeField]
        private GameObject _agree;
        [SerializeField]
        private GameObject _disAgree;

        private void Awake() 
        {
            gameObject.SetActive(false);
        }

        public void Show(DialogType type, string text, Action onAgree, Action onDisAgree = null)
        {
            var agree = _agree.GetComponent<Button>();
            var disAgree = _disAgree.GetComponent<Button>();
            _body.text = text;
            agree.onClick.AddListener(() => onAgree?.Invoke());
            agree.onClick.AddListener(() => { Destroy(gameObject); });
            disAgree.onClick.AddListener(() => onDisAgree?.Invoke());
            disAgree.onClick.AddListener(() => { Destroy(gameObject); });
            _disAgree.SetActive(type == DialogType.Switch);
            gameObject.SetActive(true);
        }
    }
}