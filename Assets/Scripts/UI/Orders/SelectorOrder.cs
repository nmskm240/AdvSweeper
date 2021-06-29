using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Orders
{
    [CreateAssetMenu(fileName = "SelectorOrder", menuName = "AdvSweeper/Order/SelectorOrder", order = 0)]
    public class SelectorOrder : Order
    {
        public MinMax Selectable = new MinMax(0, 0);
        public List<Object> Results = new List<Object>();

        public override void Reset()
        {
            base.Reset();
            Results.Clear();
            Selectable.min = 0;
            Selectable.max = 0;
        }
    }
}