using System.Collections.Generic;
using UnityEngine;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "ViewerOrder", menuName = "AdvSweeper/Order/ViewerOrder", order = 0)]
    public class ViewerOrder : ScriptableObject, IOrder
    {
        public List<string> WhiteList = new List<string>();

        public virtual void Reset()
        {
            WhiteList.Clear();
        }
    }
}