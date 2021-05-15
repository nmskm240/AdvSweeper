using UnityEngine;

namespace Sweeper.TileContents
{
    public interface ITileContents
    {
        Sprite Image{ get; }
    
        void Open();
    }
}