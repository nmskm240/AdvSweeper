using UnityEngine;
using UI;

namespace Sweeper.TileContents
{
    public class Exit : ITileContent
    {
        private Sprite _image;

        public Sprite Image{ get { return _image; } }

        public Exit()
        {
            _image = Resources.Load("Textures/Tile/Contents/Exit", typeof(Sprite)) as Sprite;
        }

        public void Open()
        {
            var factroy = new DialogFactory();
            var dialog = factroy.Create().GetComponent<Dialog>();
            dialog.Show(DialogType.Switch, "出口を見つけた。\n探索を終了しますか？", x => 
            {
                MultiSceneManagement.MultiSceneManager.LoadScene("Menu");
            }, y => { });
        }
    }
}