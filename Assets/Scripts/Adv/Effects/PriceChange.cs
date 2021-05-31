using UnityEngine;
using Adv;

namespace Adv.Effects
{
    public class PriceChange : IEffect
    {
        [SerializeField]
        private float _rate;

        public void Activate(ItemData item)
        {
            item.Price = (int)((float)item.Price * _rate);
        }
    }
}