using UnityEngine;

namespace Sweeper.TileContents
{
    public interface ITileContent
    {
        Sprite Image{ get; }
    
        void Open();
    }
}