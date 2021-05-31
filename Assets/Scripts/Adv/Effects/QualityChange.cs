using UnityEngine;
using Adv;

namespace Adv.Effects
{
    public class QualityChange : IEffect
    {
        [SerializeField]
        private int _quantity;

        public void Activate(ItemData item)
        {
            item.Quality += _quantity;
        }
    }
}