using System.Collections.Generic;
using UnityEngine;

namespace UI
{    
    [CreateAssetMenu(fileName = "ItemViewerDisplayOrder", menuName = "AdvSweeper/ItemViewerDisplayOrder", order = 0)]
    public class ItemViewerDisplayOrder : ScriptableObject 
    {
        public List<string> IDs{ get; set; } = new List<string>();
    }
}