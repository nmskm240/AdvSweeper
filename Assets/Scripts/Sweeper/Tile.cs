using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sweeper.TileContents;

namespace Sweeper
{    
    public class Tile : MonoBehaviour 
    {
        private List<Tile> _aroundTiles = new List<Tile>();
        private Dictionary<ITileContent, int> _contentsMap = new Dictionary<ITileContent, int>();

        public ITileContent Contents { get; set; } = new None();
        public IEnumerable<Tile> AroundTiles { get { return _aroundTiles; }}
        public Vector2 Pos { get; set; }
        public IDictionary<ITileContent, int> ContentsMap { get { return _contentsMap; } }
        public bool CanOpen { get; set; } = true;

        public void AddAroundTile(Tile tile)
        {
            _aroundTiles.Add(tile);
        }

        public void CountUpAroundTiles(ITileContent target)
        {
            foreach (var tile in _aroundTiles)
            {
                if(!tile.ContentsMap.ContainsKey(target))
                {
                    tile.ContentsMap.Add(target, 0);
                }
                tile.ContentsMap[target]++;
            }
        }

        public void Open()
        {
            CanOpen = false;
            Contents.Open();
        }
    }
}