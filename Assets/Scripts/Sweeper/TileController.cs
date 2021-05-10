using UnityEngine;
using UnityEngine.EventSystems;
using Sweeper.TileContents;

namespace Sweeper
{
    public class TileController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Tile _tile;
        [SerializeField]
        private TileView _tileView;

        public void OnPointerClick(PointerEventData data)
        {
            if (_tile.CanOpen)
            {
                if (_tile.ContentsMap != null)
                {
                    if (_tile.Contents.GetType() == typeof(None)) 
                    {
                        _tileView.ShowHints(_tile.ContentsMap); 
                    }
                    else 
                    { 
                        _tileView.ShowContents(_tile.Contents); 
                    }
                }
                _tile.Open();
                _tileView.Open();
            }
        }
    }
}