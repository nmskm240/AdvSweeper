using UnityEngine;
using UnityEngine.EventSystems;
using MultiSceneManagement;

namespace UI.Viewer
{    
    public class CharacteristicsNode : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData e)
        {
            MultiSceneManager.LoadScene("CharacteristicSelect");
        }
    }
}