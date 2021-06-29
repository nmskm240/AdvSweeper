using UnityEngine;
using UnityEngine.UI;
using MultiSceneManagement;

namespace UI.Selectors
{
    public abstract class Selector<T> : OrderReceiveMonoBehaviour<T> where T : Order
    {
        [SerializeField]
        protected Button _completBtn;
        [SerializeField]
        protected Button _closeBtn;

        protected virtual void Awake()
        {
            _closeBtn?.onClick.AddListener(() => OnClose());
            _completBtn?.onClick.AddListener(() => OnSelectComplete());
        }

        protected virtual void OnClose()
        {
            _order.OnOrderUnComplete?.Invoke();
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }

        protected virtual void OnSelectComplete()
        {
            _order.OnOrderComplete?.Invoke();
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }
    }
}