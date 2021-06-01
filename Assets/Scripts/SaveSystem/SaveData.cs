using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace SaveSystem
{
    [System.Serializable]
    public class SaveData : ISerializationCallbackReceiver
    {
        [SerializeField]
        private ItemCollection _container;

        public string ContainerData;

        public void OnBeforeSerialize()
        {
            ContainerData = string.Empty;
            ContainerData = _container.Serialize();
        }

        public void OnAfterDeserialize()
        {

        }
    }
}