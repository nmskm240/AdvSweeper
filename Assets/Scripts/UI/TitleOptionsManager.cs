using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MultiSceneManagement;

namespace UI
{
    public class TitleOptionsManager : MonoBehaviour
    {
        [SerializeField]
        private EventTrigger _tapZone;
        private void Awake()
        {
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((x) => { MultiSceneManager.LoadScene("Menu"); });
            _tapZone.triggers.Add(entry);
        }
    }
}