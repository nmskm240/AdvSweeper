using System.Collections.Generic;
using UnityEngine;

namespace UI.Orders
{
    [CreateAssetMenu(fileName = "SelectorOrder", menuName = "AdvSweeper/Order/SelectorOrder", order = 0)]
    public class SelectorOrder : ScriptableObject, IOrder
    {
        public int MaxNumberOfSelectable = 0;
        public int MinNumberOfSelectable = 0;
        public List<Object> Results = new List<Object>();

        public virtual void Reset()
        {
            Results.Clear();
            MaxNumberOfSelectable = 0;
            MinNumberOfSelectable = 0;
        }
    }
}