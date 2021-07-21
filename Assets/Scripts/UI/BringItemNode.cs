using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MultiSceneManagement;
using Adv;
using UI.Orders;

namespace UI
{
    public class BringItemNode : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Sprite _nonItem;

        private ItemData _item;

        private void Update()
        {
            _image.sprite = (_item == null) ? _nonItem : _item.Image;
        }

        public void OnPointerClick(PointerEventData e)
        {
            var vOrder = Resources.Load("Datas/Order/ItemViewerOrder") as ItemViewerOrder;
            var sOrder = Resources.Load("Datas/Order/SelectorOrder") as SelectorOrder;
            var bring = Resources.Load("Datas/BringIn") as ItemCollection;
            vOrder.Reset();
            vOrder.BlackList.AddRange(bring.Contents.ConvertAll(item => item.ID));
            vOrder.ItemOnly = true;
            sOrder.Reset();
            sOrder.Selectable.min = 0;
            sOrder.Selectable.max = 1;
            sOrder.OnOrderComplete.AddListener(() =>
            {
                if (_item != null)
                {
                    bring.Contents.Remove(_item);
                }
                if (0 < sOrder.Results.Count)
                {
                    _item = sOrder.Results[0] as ItemData;
                    bring.Contents.Add(_item);
                }
                else
                {
                    _item = null;
                }
            });
            MultiSceneManager.LoadScene("ItemSelect");
        }
    }
}