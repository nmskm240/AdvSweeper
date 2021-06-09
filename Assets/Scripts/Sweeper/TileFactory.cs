using UnityEngine;

namespace Sweeper
{
    public class TileFactory : Factory<GameObject>
    {
        public TileFactory()
        {
            _original = Resources.Load("Prefabs/Tile") as GameObject;
        }
    }
}