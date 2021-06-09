using UnityEngine;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "ItemViewerOrder", menuName = "AdvSweeper/Order/ItemViewerOrder", order = 0)]
    public class ItemViewerOrder : ViewerOrder 
    {
        public bool ItemOnly = false;

        public override void Reset()
        {
            base.Reset();
            ItemOnly = false;
        }
    }
}