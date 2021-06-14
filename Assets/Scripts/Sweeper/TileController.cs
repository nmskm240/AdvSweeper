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

        public Tile Tile { get { return _tile; } }
        public TileView View { get { return _tileView; } }
        public bool Openable { get; set; } = true;

        public void OnPointerClick(PointerEventData data)
        {
            if (Openable)
            {
                if (_tile.ContentsMap != null)
                {
                    if (_tile.Contents.GetType() == typeof(None)) 
                    {
                        _tileView.ShowHints(_tile.ContentsMap); 
                    }
                    else 
                    { 
                        var pickItems = GameObject.Find("PickItems");
                        var tilePos = transform.localPosition;
                        pickItems.transform.localPosition = new Vector3(tilePos.x, tilePos.y + 20f, tilePos.z);
                        _tileView.ShowContents(_tile.Contents); 
                    }
                }
                _tile.Open();
                _tileView.Open();
                Openable = _tile.Contents.GetType() == typeof(Stair) || _tile.Contents.GetType() == typeof(Stair);
            }
        }

        public void OnLongPressed()
        {
            Openable = !Openable;
            _tileView.ChangeBad();
        }
    }
}