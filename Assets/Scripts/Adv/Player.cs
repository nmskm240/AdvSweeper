using System.Collections;
using System.Collections.Generic;
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
            if(HP - quantity <= 0)
            {
                Death();
            }
            HP -= quantity;
        }

        public void GetItem(ItemData item)
        {
            _basket.Contents.Add(item);
        }

        public void GetItems(IEnumerable<ItemData> items)
        {
            foreach(var item in items)
            {
                GetItem(item);
            }
        }

        public void UseItem(ItemData item)
        {
            foreach(var effect in item.Effects)
            {
                effect.Activate();
            }
        }

        public void SeeBasket()
        {
            MultiSceneManagement.MultiSceneManager.LoadScene("Basket");
        }

        private void Death()
        {
            var factory = new DialogFactory();
            var dialog = factory.Create().GetComponent<Dialog>();
            dialog.Show(DialogType.AgreeOnly, "力尽きてしまった。\nタイトル画面に戻ります。", x => 
            { 
                MultiSceneManagement.MultiSceneManager.LoadScene("Menu");
            });
        }
    }
}