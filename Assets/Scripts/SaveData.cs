using System.Collections.Generic;
using UnityEngine;
using Adv;

[System.Serializable]
public class SaveData : ISerializationCallbackReceiver
{
    [SerializeField]
    private ItemCollection _container;

    public List<string> ContainerDatas = new List<string>();

    public void OnBeforeSerialize()
    {
        ContainerDatas.Clear();
        foreach (var item in _container.Contents)
        {
            ContainerDatas.Add(item.ToString());
        }
    }

    public void OnAfterDeserialize()
    {

    }
}