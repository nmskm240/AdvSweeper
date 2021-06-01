using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;

namespace Adv
{
    [System.Serializable, CreateAssetMenu(fileName = "ItemCollection", menuName = "AdvSweeper/ItemCollection", order = 0)]
    public class ItemCollection : ScriptableObject, ISavable<ItemCollection>
    {
        [SerializeField]
        private ItemData _template;

        public List<ItemData> Contents = new List<ItemData>();

        #if UNITY_EDITOR
        private void OnEnable()
        {
            Contents.Clear();
        }
        #endif

        public string Serialize()
        {
            var data = string.Empty;
            foreach (var item in Contents)
            {
                data += item.Serialize() + ".";
            }
            return data;
        }

        public ItemCollection Deserialize(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                foreach (var item in data.Split('.'))
                {
                    Contents.Add(_template.Deserialize(data));
                }
            }
            return this;
        }
    }
}