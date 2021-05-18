using UnityEngine;

namespace UI
{    
    public class RecipeSelector : MonoBehaviour 
    {
        [SerializeField]
        private Transform _contents;

        private IFactory<GameObject> _factory = new RecipeNodeFactory();
    }
}