using System.Collections.Generic;
using UnityEngine;
using Adv;
using UI.Orders;

namespace UI.Selectors
{
    public class ItemSelector : Selector<SelectorOrder>
    {
        protected virtual void Update()
        {
            _completBtn.interactable = (_order.Selectable.min <= _order.Results.Count && _order.Results.Count <= _order.Selectable.max);
        }
    }
}