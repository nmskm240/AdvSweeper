using UnityEngine;

namespace Sweeper.TileContents
{
    public class None : ITileContent
    {
        public Sprite Image{ get { return null; } }

        public void Open()
        {
            UnityEngine.Debug.Log("none");
        }
    }
}