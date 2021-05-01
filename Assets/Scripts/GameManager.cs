using UnityEngine;
using MultiSceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Awake() 
    {
        base.Awake();
        MultiSceneManager.Init();
        if(Application.platform == RuntimePlatform.Android) MultiSceneManager.LoadScene("Title");
    }
}