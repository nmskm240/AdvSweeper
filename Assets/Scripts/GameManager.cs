using MultiSceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Awake() 
    {
        base.Awake();
        MultiSceneManager.Init();
        if(!UnityEditor.EditorApplication.isPlaying) MultiSceneManager.LoadScene("Title");
    }
}