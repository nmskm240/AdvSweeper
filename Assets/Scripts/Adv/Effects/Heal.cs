using UnityEngine;
using Adv;

namespace Adv.Effects
{
    public class Heal : IEffect
    {
        [SerializeField]
        private int _quantity;

        public void Activate()
        {
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.HP += _quantity;
        }
    }
}