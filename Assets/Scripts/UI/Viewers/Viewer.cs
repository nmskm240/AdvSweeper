using UnityEngine;
using UnityEngine.UI;
using MultiSceneManagement;

namespace UI.Viewers
{    
    public abstract class Viewer<T> : OrderReceiveMonoBehaviour<T> where T : ScriptableObject, IOrder
    {
        [SerializeField]
        protected Transform _contents;

        protected virtual void Start()
        {
            Show();
        }

        protected void ContentsReset()
        {
            foreach(Transform tf in _contents)
            {
                Destroy(tf.gameObject);
            }
        }

        public abstract void Show();
    }
}