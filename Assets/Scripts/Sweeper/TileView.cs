using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Sweeper.TileContents;
using UI;

namespace Sweeper
{
    public class TileView : MonoBehaviour
    {
        [SerializeField]
        private Image _tileImage;
        [SerializeField]
        private Transform _hints;
        [SerializeField]
        private GameObject _contents;
        [SerializeField]
        private GameObject _bad;
        [SerializeField]
        private Animator _animator;

        private void Awake() 
        {
            _tileImage.sprite = Resources.Load("Textures/Tile/Face", typeof(Sprite)) as Sprite;
        }

        public void Open()
        {
            _animator.SetTrigger("Open");
        }

        public void ShowHints(IDictionary<Type, int> contentsMap)
        {
            var factory = new ContentsCounterFactory();
            foreach(var keyValuePair in contentsMap)
            {
                var obj = factory.Create();
                var contentsCounter = obj.GetComponent<ContentsCounter>();
                var constructor = keyValuePair.Key.GetConstructor(Type.EmptyTypes);
                var contents = constructor.Invoke(null) as ITileContent;
                contentsCounter.Init(contents.Image, keyValuePair.Value);
                obj.transform.SetParent(_hints);
                obj.transform.localScale = Vector3.one;
            }
        }

        public void ShowContents(ITileContent contents)
        {
            _contents.GetComponent<Image>().sprite = contents.Image;
        }

        public void ChangeBad()
        {
            _bad.SetActive(!_bad.activeSelf);
        }
    }
}