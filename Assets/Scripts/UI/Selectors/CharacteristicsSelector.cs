using UI.Orders;

namespace UI.Selectors
{
    public class CharacteristicsSelector : Selector<SelectorOrder>
    {
        private void Update()
        {
            _completBtn.interactable = (_order.MinNumberOfSelectable <= _order.Results.Count && _order.Results.Count <= _order.MaxNumberOfSelectable);
        }
    }
}