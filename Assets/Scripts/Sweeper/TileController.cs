using System.Collections;
using System.Collections.Generic;
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
                    switch (_tile.Contents)
                    {
                        case None non:
                            foreach (var keyValuePair in _tile.ContentsMap)
                            {
                                _tileView.ShowHint(keyValuePair);
                            }
                            break;
                        case Enemy ene:
                        case Storage sto:
                        case Stair sta:
                            _tileView.ShowContents(_tile.Contents);
                            break;
                    }
                }
                _tile.Open();
                _tileView.Open();
            }
        }
    }
}