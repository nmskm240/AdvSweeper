using UnityEngine;

namespace MultiSceneManagement
{    
    public class MultiSceneLoader : MonoBehaviour 
    {
        public void Load(string sceneName)
        {
            MultiSceneManager.LoadScene(sceneName);
        }
    }
}