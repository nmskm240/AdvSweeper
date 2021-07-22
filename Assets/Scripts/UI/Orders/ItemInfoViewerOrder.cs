using Adv;
using UI.Viewers;

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

        public void DataSet(ItemNode node)
        {
            Data = node.Item;
        }
    }
}