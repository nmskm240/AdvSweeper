using UnityEngine;
using Sweeper;
using UI;

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
            var factory = new DialogFactory();
            var dialog = factory.Create().GetComponent<Dialog>();
            dialog.Show("次の階へ移動しますか？", x => 
            {
                Debug.Log("agree");
            }, y =>
            {
                Debug.Log("disagree");
            });
            UnityEngine.Debug.Log("stair");
        }
    }
}