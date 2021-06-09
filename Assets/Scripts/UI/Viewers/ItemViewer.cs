using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MultiSceneManagement;
using Adv;
using UI.Orders;

namespace UI.Viewers
{
    public class ItemViewer : Viewer<ItemViewerOrder>
    {
        [SerializeField]
        private ItemCollection _collections;

        private void CreateItemNode(ItemData item)
        {
            var factory = new ItemNodeFactory();
            var obj = factory.Create();
            var node = obj.GetComponent<ItemNode>();
            obj.transform.SetParent(_contents);
            obj.transform.localScale = Vector3.one;
            node.Init(item);
        }

        public override void Show()
        {
            ContentsReset();
            foreach (var item in _collections.Contents)
            {
                if(_order.ItemOnly != item.IsItem)
                {
                    continue;
                }
                if (_order.WhiteList.Count > 0)
                {
                    foreach (var id in _order.WhiteList)
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
        }
    }
}