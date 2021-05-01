using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace UI
{
    public class ItemViewer : MonoBehaviour
    {
        [SerializeField]
        private Transform _contents;

        private IFactory<GameObject> _factory = new ItemNodeFactory();
        private Dictionary<ItemData, GameObject> _nodes = new Dictionary<ItemData, GameObject>();

        public void AddItem(ItemData item)
        {
            if (_nodes.ContainsKey(item))
            {
                _nodes[item].GetComponent<ItemNode>().Holding++;
            }
            else
            {
                var obj = _factory.Create();
                var node = obj.GetComponent<ItemNode>();
                _nodes.Add(item, obj);
                node.Init(item);
                obj.transform.SetParent(_contents);
                obj.transform.localScale = Vector3.one;
            }
        }
    }
}