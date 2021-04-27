using UnityEngine;
using UI;

namespace Adv
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private SliderParameter _hp;
        [SerializeField]
        private SliderParameter _mp;

        public int HP{ get; private set; } = 4;
        public int MP{ get; private set; } = 4;

        private void Awake()
        {
            _hp.Range(0, HP);
            _hp.Value = HP;
            _mp.Range(0, MP);
            _mp.Value = MP;
        }

        public void Damage(int quantity)
        {
            HP -= quantity;
            _hp.Value = HP;
            if(HP <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            var factory = new DialogFactory();
            var dialog = factory.Create().GetComponent<Dialog>();
            dialog.Show("死亡", x => {}, y => {});
        }
    }
}