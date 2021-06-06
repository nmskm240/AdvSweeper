using UnityEngine;
using UnityEngine.UI;
using MultiSceneManagement;

namespace UI.Viewers
{    
    public abstract class Selector<T> : OrderReceiveMonoBehaviour<T> where T : ScriptableObject, IOrder
    {
        [SerializeField]
        protected Button _completBtn;

        protected virtual void Awake()
        {
            _completBtn.onClick.AddListener(() => OnSelectComplet());
        }

        protected virtual void OnSelectComplet()
        {
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }
    }
}