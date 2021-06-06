using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace UI.Viewers
{
    public class ItemSelector : Selector<SelectorOrder>
    {
        protected virtual void Update()
        {
            _completBtn.interactable = (_order.MinNumberOfSelectable <= _order.Results.Count && _order.Results.Count <= _order.MaxNumberOfSelectable);
        }
    }
}