using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adv;

namespace UI.Viewers
{
    public class ItemSelector : ItemViewer
    {
        [SerializeReference]
        private ItemCollection _selectedItems;

        private int _selectNum;

        protected override void Awake()
        {
            base.Awake();
            if(_order is ItemSelectOrder)
            {
                _selectNum = (_order as ItemSelectOrder).SelectNum;
            }
        }

        private void Update()
        {
            _closeButton.interactable = _selectedItems.Contents.Count == _selectNum;
        }
    }
}