using UnityEngine;
using MultiSceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake() 
    {
        MultiSceneManager.Init();
        if(Application.platform == RuntimePlatform.Android) MultiSceneManager.LoadScene("Title");
    }
}