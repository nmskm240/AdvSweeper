using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{
    public class ItemDataCompare : IEqualityComparer<ItemData>
    {
        public bool Equals(ItemData item1, ItemData item2)
        {
            if(item1 == null || item2 == null) return false;
            if(object.ReferenceEquals(item1, item2)) return true;
            else if(item1.GetInstanceID() == item2.GetInstanceID()) return true;
            return false;
        }

        public int GetHashCode(ItemData item)
        {
            return item.GetInstanceID().GetHashCode();
        }
    }
}