using UnityEngine;

namespace Sweeper.TileContents
{
    public class None : ITileContents
    {
        public Sprite Image{ get { return null; } }

        public None(){}

        public void Open()
        {
            UnityEngine.Debug.Log("none");
        }
    }
}