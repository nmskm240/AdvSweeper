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
            var path = new Vector3[]
            {
                new Vector3(UnityEngine.Random.Range(-50,50) + _rectTransform.position.x, 25f + _rectTransform.position.y, 0f),
                new Vector3(tf.position.x, tf.position.y, tf.position.z),
            };
            _rectTransform.DOPath(path, 1.75f, PathType.CatmullRom).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}