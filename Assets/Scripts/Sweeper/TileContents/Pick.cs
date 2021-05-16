using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Adv;
using UI;

namespace Sweeper.TileContents
{
    public class Pick : ITileContents
    {
        private List<ItemData> _datas;
        private Sprite _image;

        public Sprite Image{ get { return _image; } }

        public Pick()
        {
            _image = Resources.Load("Textures/Tile/Contents/Pick", typeof(Sprite)) as Sprite;
        }

        public Pick(IEnumerable<ItemData> datas)
        {
            _image = Resources.Load("Textures/Tile/Contents/Pick", typeof(Sprite)) as Sprite;
            _datas = new List<ItemData>(datas);
        }

        public void Open()
        {
            var player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player.GetItems(_datas);
            Observable.FromCoroutine(OpenProcess).Subscribe(x => {});
        }

        private IEnumerator OpenProcess()
        {
            var factory = new PickItemFactory();
            var pickItems = GameObject.Find("PickItems");
            var basketRect = GameObject.Find("Basket").GetComponent<RectTransform>();
            foreach(var item in _datas)
            {
                var obj = factory.Create();
                var pickItem = obj.GetComponent<PickItem>();
                obj.transform.SetParent(pickItems.transform);
                obj.transform.localScale = Vector3.one;
                obj.transform.localPosition = Vector3.zero;
                pickItem.Init(item.Image);
                pickItem.Move(basketRect);
                yield return null;
            }
        }
    }
}