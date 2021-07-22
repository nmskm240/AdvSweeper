using System.Collections.Generic;
using UnityEngine;

namespace UI.Orders
{
    [CreateAssetMenu(fileName = "ItemViewerOrder", menuName = "AdvSweeper/Order/CharacteristicsViewerOrder", order = 0)]
    public class CharacteristicsViewerOrder : Order
    {
        public List<string> Contents = new List<string>();

        public override void Reset() 
        {
            Contents.Clear();
        }
    }
}