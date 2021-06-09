using Adv;

namespace UI.Orders
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "ItemInfoViewerOrder", menuName = "AdvSweeper/Order/ItemInfoViewerOrder", order = 0)]
    public class ItemInfoViewerOrder : ScriptableObject, IOrder
    {
        public ItemData Data;

        public void Reset()
        {
            Data = null;
        }
    }
}