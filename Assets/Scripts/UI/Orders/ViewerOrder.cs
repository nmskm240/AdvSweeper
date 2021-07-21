using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "ViewerOrder", menuName = "AdvSweeper/Order/ViewerOrder", order = 0)]
    public class ViewerOrder : Order
    {
        public List<string> WhiteList = new List<string>();
        public List<string> BlackList = new List<string>();

        public override void Reset()
        {
            base.Reset();
            WhiteList.Clear();
            BlackList.Clear();
        }
    }
}