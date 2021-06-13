using UnityEngine;
using Sweeper;
using Sweeper.TileContents;

namespace Adv.Effects
{
    public class Search : IEffect
    {
        [SerializeField]
        private ITileContents _targetContents;

        public void Activate(ItemData item)
        {
            var stage = GameObject.Find("Stage").GetComponent<Stage>();
            foreach(var obj in stage.Map)
            {
                var tileController = obj.GetComponent<TileController>();
                if(tileController.Tile.Contents.GetType() == _targetContents.GetType() && tileController.Openable)
                {
                    var tileView = obj.GetComponent<TileView>();
                    tileView.ShowContents(_targetContents);
                }
            }
        }
    }
}