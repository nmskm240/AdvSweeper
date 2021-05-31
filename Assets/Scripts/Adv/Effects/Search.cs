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
                var tile = obj.GetComponent<Tile>();
                if(tile.Contents.GetType() == _targetContents.GetType() && tile.CanOpen)
                {
                    var tileView = obj.GetComponent<TileView>();
                    tileView.ShowContents(_targetContents);
                }
            }
        }
    }
}