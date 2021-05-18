using System.Collections;
using System.Linq;
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

        private ItemViewerDisplayOrder _order;
        private IFactory<GameObject> _factory = new ItemNodeFactory();

        private void Awake()
        {
            _order = Resources.Load("Datas/ItemViewerOrder") as ItemViewerDisplayOrder;
            Show(_collections);
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
                            var obj = _factory.Create();
                            var node = obj.GetComponent<ItemNode>();
                            obj.transform.SetParent(_contents);
                            obj.transform.localScale = Vector3.one;
                            node.Init(item);
                            break;
                        }
                    }
                }
                else
                {
                    var obj = _factory.Create();
                    var node = obj.GetComponent<ItemNode>();
                    obj.transform.SetParent(_contents);
                    obj.transform.localScale = Vector3.one;
                    node.Init(item);
                }
            }
            OrderReset();
        }

        public void OrderReset()
        {
            Resources.UnloadAsset(_order);
        }

        public void Close()
        {
            MultiSceneManager.UnloadScene(gameObject.scene.name);
        }
    }
}