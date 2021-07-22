using System.Collections.Generic;
using UnityEngine;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "ItemViewerOrder", menuName = "AdvSweeper/Order/ItemViewerOrder", order = 0)]
    public class ItemViewerOrder : Order 
    {
        public List<string> WhiteList = new List<string>();
        public List<string> BlackList = new List<string>();
        public bool ItemOnly = false;

        public override void Reset()
        {
            WhiteList.Clear();
            BlackList.Clear();
            ItemOnly = false;
        }
    }
}