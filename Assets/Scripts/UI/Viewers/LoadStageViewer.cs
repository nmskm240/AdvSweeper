using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI.Orders;

namespace UI.Viewers
{
    public class LoadStageViewer : Viewer<LoadStageOrder>
    {
        [SerializeField]
        private TextMeshProUGUI _stageName;
        [SerializeField]
        private ContentsIconsViewer _spawnEnemys;
        [SerializeField]
        private ContentsIconsViewer _pickItems;

        public override void Show()
        {
            _stageName.text = _order.Data.Name;
            _spawnEnemys.SetContentsIcons(_order.Data.SpawnTable.Select(e => e.Node));
            _pickItems.SetContentsIcons(_order.Data.ItemTable.Select(e => e.Node));
        }
    }
}