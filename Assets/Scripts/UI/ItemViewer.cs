using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField]
        protected ItemViewOrder _order;
        [SerializeField]
        protected Button _closeButton;

        private IFactory<GameObject> _factory = new ItemNodeFactory();

        protected virtual void Awake()
        {
            _closeButton?.onClick.AddListener(() => Close());
            Show(_collections);
        }

        private void CreateItemNode(ItemData item)
        {
            var obj = _factory.Create();
            var node = obj.GetComponent<ItemNode>();
            obj.transform.SetParent(_contents);
            obj.transform.localScale = Vector3.one;
            node.Init(item);
        }

        protected virtual void Close()
        {
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }

        public void Show(ItemCollection collection)
        {
            foreach (var item in collection.Contents)
            {
                if (_order.IDs.Count > 0)
                {
                    foreach (var id in _order.IDs)
                    {
                        if (item.ID == id
                         || item.Categories.Any(c => c.ID == id)
                         || item.Characteristics.Any(c => c.ID == id))
                        {
                            CreateItemNode(item);
                            break;
                        }
                    }
                }
                else
                {
                    CreateItemNode(item);
                }
            }
            _order.Reset();
        }
    }
}