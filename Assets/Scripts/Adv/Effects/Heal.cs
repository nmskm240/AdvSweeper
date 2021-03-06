using UnityEngine;
using Adv;

namespace Adv.Effects
{
    public class Heal : IEffect
    {
        [SerializeField]
        private int _quantity;

        public void Activate(ItemData item)
        {
            var player = GameObject.FindWithTag("Player").GetComponent<Treasure>();
            player.HP += _quantity;
        }
    }
}