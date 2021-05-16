using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sweeper.TileContents;
using Adv;
using UI;

namespace Sweeper
{    
    public class Tile : MonoBehaviour 
    {
        private List<Tile> _aroundTiles = new List<Tile>();
        private Dictionary<Type, int> _contentsMap = new Dictionary<Type, int>();

        public ITileContents Contents { get; set; } = new None();
        public IEnumerable<Tile> AroundTiles { get { return _aroundTiles; }}
        public Vector2 Pos { get; set; }
        public IDictionary<Type, int> ContentsMap { get { return _contentsMap; } }
        public bool CanOpen { get; set; } = true;

        public void AddAroundTile(Tile tile)
        {
            _aroundTiles.Add(tile);
        }

        public void CountUpAroundTiles(ITileContents target)
        {
            var type = target.GetType();
            foreach (var tile in _aroundTiles)
            {
                if(!tile.ContentsMap.ContainsKey(type))
                {
                    tile.ContentsMap.Add(type, 0);
                }
                tile.ContentsMap[type]++;
            }
        }

        public void Open()
        {
            var timer = GameObject.Find("Timer").GetComponent<ContentsCounter>();
            timer.Value--;
            if(timer.Value <= 0 && Contents.GetType() != typeof(Enemy))
            {
                var player = GameObject.FindWithTag("Player").GetComponent<Player>();
                player.Damage(1);
            }
            CanOpen = (Contents.GetType() == typeof(Stair) || Contents.GetType() == typeof(Exit));
            Contents.Open();
        }
    }
}