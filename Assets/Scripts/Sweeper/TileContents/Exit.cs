using UnityEngine;
using MultiSceneManagement;
using Adv;
using UI.Popups;

namespace Sweeper.TileContents
{
    public class Exit : ITileContents
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
            dialog.Show(DialogType.Switch, "出口を見つけた。\n探索を終了しますか？", () => 
            {
                var player = GameObject.FindWithTag("Player").GetComponent<Treasure>();
                player.SwapToContainer();
                MultiSceneManager.LoadScene("Menu");
            });
        }
    }
}