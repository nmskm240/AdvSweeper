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
        private ItemViewer _itemViewer;

        private Dictionary<ItemData, int> _items = new Dictionary<ItemData, int>();

        public int HP{ get; private set; } = 4;
        public int MP{ get; private set; } = 4;
        public IDictionary<ItemData, int> Items { get { return _items; } }

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

        public void GetItem(ItemData item)
        {
            if(!_items.ContainsKey(item))
            {
                _items.Add(item, 0);
            }
            _items[item]++;
            _itemViewer.AddItem(item);
        }

        public void UseItem(ItemData item)
        {
            if(!_items.ContainsKey(item))
            {
                return;
            }
            _items[item]--;
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