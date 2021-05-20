using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv;

public abstract class Player : MonoBehaviour
{
    [SerializeField]
    protected ItemCollection _container;

    public virtual void GetItem(ItemData item)
    {
        _container.Contents.Add(item);
    }

    public void GetItems(IEnumerable<ItemData> items)
    {
        foreach (var item in items)
        {
            GetItem(item);
        }
    }

    public virtual void RemoveItem(ItemData item)
    {
        _container.Contents.Remove(item);
    }

    public void RemoveItems(IEnumerable<ItemData> items)
    {
        foreach(var item in items)
        {
            RemoveItem(item);
        }
    }
}