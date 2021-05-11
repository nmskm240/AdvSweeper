using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv;

namespace Sweeper.TileContents
{
    public class Pick : ITileContent
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
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.GetItems(_datas);
        }
    }
}