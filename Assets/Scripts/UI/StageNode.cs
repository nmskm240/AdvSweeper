using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using Adv;

namespace UI
{    
    public class StageNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Text _text;
        [SerializeField]
        private StageData _base;
        [SerializeField]
        private StageData _loadStageData;

        private void Awake() 
        {
            _text.text = _base.Name;
        }

        public void OnPointerClick(PointerEventData e)
        {
            _loadStageData.Copy(_base);
            MultiSceneManager.LoadScene("Game");
        }
    }
}