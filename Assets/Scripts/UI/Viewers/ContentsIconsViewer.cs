using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Viewers
{    
    public class ContentsIconsViewer : MonoBehaviour 
    {
        [SerializeField]
        private Image _template;
        [SerializeField]
        private Transform _parent;

        public void SetContentsIcons(IEnumerable<BaseData> contents)
        {
            foreach(var data in contents)
            {
                var obj = Instantiate(_template.gameObject);
                var image = obj.GetComponent<Image>();
                image.sprite = data.Image;
                obj.transform.SetParent(_parent);
                obj.transform.localScale = Vector3.one;
                obj.SetActive(true);
            }
        }
    }
}