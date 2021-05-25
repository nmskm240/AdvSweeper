using System.Collections.Generic;
using UnityEngine;

namespace UI.Viewers
{    
    [CreateAssetMenu(fileName = "ItemViewOrder", menuName = "AdvSweeper/ItemViewOrder", order = 0)]
    public class ItemViewOrder : ScriptableObject 
    {
        public List<string> IDs{ get; set; } = new List<string>();

        public void Reset()
        {
            IDs.Clear();
        }
    }
}