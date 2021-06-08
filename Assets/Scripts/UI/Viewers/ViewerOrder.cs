using System.Collections.Generic;
using UnityEngine;

namespace UI.Viewers
{    
    [CreateAssetMenu(fileName = "ViewerOrder", menuName = "AdvSweeper/Order/ViewerOrder", order = 0)]
    public class ViewerOrder : ScriptableObject, IOrder
    {
        public List<string> WhiteList = new List<string>();

        public void Reset()
        {
            WhiteList.Clear();
        }
    }
}