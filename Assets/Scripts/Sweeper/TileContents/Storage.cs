using UnityEngine;
using Adv;

namespace Sweeper.TileContents
{
    public class Storage : ITileContent
    {
        private ItemData _data;
        private Sprite _image;

        public Sprite Image{ get { return _image; } }

        public Storage(){}

        public Storage(ItemData data)
        {
            _image = Resources.Load("Textures/Tile/Contents/Storage", typeof(Sprite)) as Sprite;
            _data = data;
        }

        public void Open()
        {
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.GetItem(_data);
        }
    }
}