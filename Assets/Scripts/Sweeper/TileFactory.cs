using UnityEngine;

namespace Sweeper
{
    public class TileFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
        }
    }
}