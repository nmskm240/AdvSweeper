using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Adv
{
    public class Treasure : Player
    {
        [SerializeField]
        private SliderParameter _hp;
        [SerializeField]
        private SliderParameter _mp;
        [SerializeField]
        private ItemCollection _basket;

        public int HP
        {
            get { return (int)_hp.Value; }
            set { _hp.Value = value; }
        }
        public int MP
        {
            get { return (int)_mp.Value; }
            set { _mp.Value = value; }
        }

        private void Awake()
        {
            _hp.Range(0, HP);
            _hp.Value = HP;
            _mp.Range(0, MP);
            _mp.Value = MP;
        }

        public void Damage(int quantity)
        {
            if (HP - quantity <= 0)
            {
                Death();
            }
            HP -= quantity;
        }

        public override void GetItem(ItemData item)
        {
            _basket.Contents.Add(item);
        }

        public void SeeBasket()
        {
            MultiSceneManagement.MultiSceneManager.LoadScene("Basket");
        }

        public void SwapToContainer()
        {
            _container.Contents.AddRange(_basket.Contents);
            _basket.Contents.Clear();
        }

        private void Death()
        {
            var factory = new DialogFactory();
            var dialog = factory.Create().GetComponent<Dialog>();
            dialog.Show(DialogType.AgreeOnly, "力尽きてしまった。\nメニュー画面に戻ります。", () =>
            {
                MultiSceneManagement.MultiSceneManager.LoadScene("StageSelect");
            });
        }
    }
}