using UnityEngine;
using UnityEngine.UI;
using MultiSceneManagement;

namespace UI.Selectors
{
    public abstract class Selector<T> : OrderReceiveMonoBehaviour<T> where T : Order
    {
        [SerializeField]
        protected Button _completBtn;

        protected virtual void Start()
        {
            _completBtn.onClick.AddListener(() => OnSelectComplet());
        }

        protected virtual void OnSelectComplet()
        {
            _order.OnOrderComplete?.Invoke();
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }
    }
}