using UnityEngine;
using UI.Popups;

namespace Sweeper.TileContents
{
    public class Stair : ITileContents
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
            dialog.Show(DialogType.Switch, "次の階へ移動しますか？", () => 
            {
                var stage = GameObject.Find("Stage").GetComponent<Stage>();
                stage.Next();
            });
        }
    }
}