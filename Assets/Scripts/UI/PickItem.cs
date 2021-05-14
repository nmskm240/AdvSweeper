using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI
{    
    public class PickItem : MonoBehaviour 
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private RectTransform _rectTransform;

        public void Init(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void Move(Transform tf)
        {
            _rectTransform.DOMove(tf.position, 1.75f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}