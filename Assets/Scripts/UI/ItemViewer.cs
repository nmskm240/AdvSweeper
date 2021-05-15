using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;
using Adv;

namespace UI
{
    public class ItemViewer : MonoBehaviour
    {
        [SerializeField]
        private Transform _contents;
        [SerializeField]
        private ItemCollection _collections;

        private IFactory<GameObject> _factory = new ItemNodeFactory();
    
        private void Awake() 
        {
            Show(_collections);
        }

        public void Show(ItemCollection collection)
        {
            foreach(var item in collection.Contents)
            {
                var obj = _factory.Create();
                var node = obj.GetComponent<ItemNode>();
                obj.transform.SetParent(_contents);
                obj.transform.localScale = Vector3.one;
                node.Init(item);
            }
        }

        public void Close()
        {
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }
    }
}