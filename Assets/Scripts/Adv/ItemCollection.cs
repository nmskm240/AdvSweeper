using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "ItemCollection", menuName = "AdvSweeper/ItemCollection", order = 0)]
    public class ItemCollection : ScriptableObject 
    {
        public List<ItemData> Contents = new List<ItemData>();
    }
}