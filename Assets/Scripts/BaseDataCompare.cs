using System.Collections.Generic;

public class BaseDataCompare : IEqualityComparer<BaseData>
{
    public bool Equals(BaseData data1, BaseData data2)
    {
        if (data1 == null || data2 == null) return false;
        if (object.ReferenceEquals(data1, data2)) return true;
        else if (data1.ID == data2.ID)
        {
            UnityEngine.Debug.Log("o");
            return true;
        }
        return false;
    }

    public int GetHashCode(BaseData item)
    {
        return item.ID.GetHashCode();
    }
}