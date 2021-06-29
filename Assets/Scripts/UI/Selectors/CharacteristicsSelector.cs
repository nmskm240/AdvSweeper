using UI.Orders;

namespace UI.Selectors
{
    public class CharacteristicsSelector : Selector<SelectorOrder>
    {
        private void Update()
        {
            _completBtn.interactable = (_order.Selectable.min <= _order.Results.Count && _order.Results.Count <= _order.Selectable.max);
        }
    }
}