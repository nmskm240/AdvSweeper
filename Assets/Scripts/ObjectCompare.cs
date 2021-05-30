using System.Collections.Generic;
using UnityEngine;

public class ObjectCompare<T> : IEqualityComparer<T> where T : Object
{
    public bool Equals(T data1, T data2)
    {
        if (data1 == null || data2 == null) return false;
        if (object.ReferenceEquals(data1, data2)) return true;
        else if (data1.GetInstanceID() == data2.GetInstanceID())
        {
            return true;
        }
        return false;
    }

    public int GetHashCode(T data)
    {
        return data.GetInstanceID().GetHashCode();
    }
}