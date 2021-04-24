using UnityEngine;
using Sweeper;

namespace Sweeper.TileContents
{
    public class Stair : ITileContent
    {
        private Sprite _image;

        public Sprite Image{ get { return _image; } }

        public Stair()
        {
            _image = Resources.Load("Textures/Tile/Contents/Stair", typeof(Sprite)) as Sprite;
        }

        public void Open()
        {
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            UnityEngine.Debug.Log("stair");
        }
    }
}