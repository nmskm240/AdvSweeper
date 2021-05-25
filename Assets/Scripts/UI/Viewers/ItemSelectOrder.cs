using UnityEngine;

namespace UI.Viewers
{
    [CreateAssetMenu(fileName = "ItemSelectOrder", menuName = "AdvSweeper/ItemSelectOrder", order = 0)]
    public class ItemSelectOrder : ItemViewOrder
    {
        public int SelectNum = 0;
    }
}