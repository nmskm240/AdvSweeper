using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{    
    public class Dialog : MonoBehaviour 
    {
        [SerializeField]
        private Text _body;
        [SerializeField]
        private Button _agree;
        [SerializeField]
        private Button _disAgree;

        private void Awake() 
        {
            gameObject.SetActive(false);
        }

        public void Show(string text, Action<string> onAgree, Action<string> onDisAgree)
        {
            _body.text = text;
            _agree.onClick.AddListener(() => onAgree?.Invoke(null));
            _agree.onClick.AddListener(() => { Destroy(gameObject); });
            _disAgree.onClick.AddListener(() => onDisAgree?.Invoke(null));
            _disAgree.onClick.AddListener(() => { Destroy(gameObject); });
            gameObject.SetActive(true);
        }
    }
}