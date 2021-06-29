using UnityEngine.Events;
using Adv;

namespace UI.Orders
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "ItemInfoViewerOrder", menuName = "AdvSweeper/Order/ItemInfoViewerOrder", order = 0)]
    public class ItemInfoViewerOrder : Order
    {
        public ItemData Data;

        public override void Reset()
        {
            base.Reset();
            Data = null;
        }
    }
}