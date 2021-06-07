using UnityEngine;
using UnityEngine.EventSystems;
using MultiSceneManagement;

namespace UI.Viewers
{    
    public class CharacteristicsNode : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData e)
        {
            MultiSceneManager.LoadScene("CharacteristicSelect");
        }
    }
}