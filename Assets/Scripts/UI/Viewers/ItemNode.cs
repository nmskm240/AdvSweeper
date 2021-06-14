using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using MultiSceneManagement;
using Adv;
using Alchemy;
using UI.Popups;
using UI.Orders;

namespace UI.Viewers
{
    public class ItemNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _text;

        private int _holding = 1;
        private ItemData _item;

        public ItemData Item { get { return _item; } }
        public int Holding
        {
            get { return _holding; }
            set
            {
                _holding = value;
                gameObject.SetActive(!(_holding <= 0));
                _text.text = "×" + _holding;
            }
        }

        private void Start()
        {
            if (gameObject.scene.name == "ItemSelect")
            {
                var selectorOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
                _image.color = (selectorOrder.Results.Contains(_item, new ObjectCompare<Object>())) ? Color.gray : Color.white;
            }
        }

        public void Init(ItemData item)
        {
            _item = item;
            _image.sprite = _item.Image;
            _text.enabled = item.IsItem;
            _text.text = "x" + _holding;
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (gameObject.scene.name == "Game" && _item.IsItem)
            {
                var factroy = new DialogFactory();
                var dialog = factroy.Create().GetComponent<Dialog>();
                dialog.Show(DialogType.AgreeOnly, _item.Name + "を使用しますか?", () =>
                {
                    var player = GameObject.FindWithTag("Player").GetComponent<Treasure>();
                });
            }
            else if (gameObject.scene.name == "ItemSelect")
            {
                var selectorOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
                if (selectorOrder.Results.Contains(_item, new ObjectCompare<Object>()))
                {
                    _image.color = Color.white;
                    selectorOrder.Results.Remove(_item);
                }
                else
                {
                    _image.color = Color.gray;
                    selectorOrder.Results.Add(_item);
                }
            }
        }

        public void OnLongPressed()
        {
            var item = Resources.Load("Datas/Order/ItemInfoViewerOrder") as ItemInfoViewerOrder;
            item.Data = _item;
            MultiSceneManager.LoadScene("ItemInfo");
        }
    }
}