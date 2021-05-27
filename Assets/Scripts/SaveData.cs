using System.Collections.Generic;
using UnityEngine;
using Adv;

[System.Serializable]
public class SaveData : ISerializationCallbackReceiver
{
    private ItemCollection _container;

    public List<string> Container = new List<string>();

    public SaveData(ItemCollection container)
    {
        _container = container;
    }

    public void OnBeforeSerialize()
    {
        foreach (var item in _container.Contents)
        {
            Container.Add(item.ToString());
        }
    }

    public void OnAfterDeserialize()
    {

    }
}