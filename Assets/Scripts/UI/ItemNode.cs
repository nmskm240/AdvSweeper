using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Adv;

namespace UI
{    
    public class ItemNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _text;
        
        private int _holding = 1;
        private ItemData _item;

        public ItemData Item{ get { return _item; } }
        public int Holding
        {
            get { return _holding; }
            set 
            {
                _holding = value;
                if(_holding <= 0)
                {
                    Destroy(gameObject);
                } 
                _text.text = "×" + _holding;
            }
        }

        public void Init(ItemData item)
        {
            _item = item;
            _image.sprite = _item.Image;
            _text.text = "x" + _holding;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var factroy = new DialogFactory();
            var dialog = factroy.Create().GetComponent<Dialog>();
            dialog.Show(DialogType.AgreeOnly, _item.Name + "を使用しますか?", x => 
            {
                var player = GameObject.Find("Player").GetComponent<Player>();
                player.UseItem(_item);
                Holding--;
            });
        }
    }
}