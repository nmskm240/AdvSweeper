using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using MultiSceneManagement;
using Adv;
using Alchemy;

namespace UI
{
    public class ItemNode : LongPressMonoBehaviour, IPointerClickHandler
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

        protected override void Start()
        {
            base.Start();
            if (gameObject.scene.name == "MaterialSelect")
            {
                var selectMaterial = Resources.Load("Datas/SelectMaterials") as ItemCollection;
                _image.color = (selectMaterial.Contents.Contains(_item, new ItemDataCompare())) ? Color.gray : Color.white;
            }
        }

        public void Init(ItemData item)
        {
            _item = item;
            _image.sprite = _item.Image;
            _text.enabled = !item.IsMaterial;
            _text.text = "x" + _holding;
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (gameObject.scene.name == "Game" && !_item.IsMaterial)
            {
                var factroy = new DialogFactory();
                var dialog = factroy.Create().GetComponent<Dialog>();
                dialog.Show(DialogType.AgreeOnly, _item.Name + "を使用しますか?", () =>
                {
                    var player = GameObject.FindWithTag("Player").GetComponent<Treasure>();
                });
            }
            else if (gameObject.scene.name == "MaterialSelect")
            {
                var selectMaterial = Resources.Load("Datas/SelectMaterials") as ItemCollection;
                if (selectMaterial.Contents.Contains(_item, new ItemDataCompare()))
                {
                    _image.color = Color.white;
                    selectMaterial.Contents.Remove(_item);
                }
                else
                {
                    _image.color = Color.gray;
                    selectMaterial.Contents.Add(_item);
                }
            }
        }

        protected override void OnLongPressed()
        {
            var item = Resources.Load("Datas/ItemInfoOrder") as ItemData;
            item.Copy(_item);
            MultiSceneManager.LoadScene("ItemInfo");
        }
    }
}