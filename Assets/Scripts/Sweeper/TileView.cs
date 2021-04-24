using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sweeper.TileContents;

namespace Sweeper
{
    public class TileView : MonoBehaviour
    {
        [SerializeField]
        private Image _tileImage;
        [SerializeField]
        private GameObject _hints;
        [SerializeField]
        private GameObject _contents;
        [SerializeField]
        private GameObject _bad;
        [SerializeField]
        private Color _openColor;
        [SerializeField]
        private Color _closeColor;

        private void Awake() 
        {
            _tileImage.sprite = Resources.Load("Textures/Tile/Face", typeof(Sprite)) as Sprite;
            Close();
        }

        public void Open()
        {
            _tileImage.color = _openColor;//new Color(0.25f, 0.25f, 0.25f);
        }

        public void Close()
        {
            _tileImage.color = _closeColor;//new Color(0.75f, 0.75f, 0.75f);
            _contents.SetActive(false);
        }

        public void ShowHint(KeyValuePair<ITileContent, int> contentsMap)
        {
            switch(contentsMap.Key)
            {
                case None non:
                    break;
                case Enemy ene:
                    var enemy = _hints.transform.Find("Enemy").gameObject;
                    enemy.transform.Find("Text").GetComponent<Text>().text = "x" + contentsMap.Value.ToString();
                    enemy.SetActive(true);
                    break;
                case Storage sto:
                    var storage = _hints.transform.Find("Storage").gameObject;
                    storage.transform.Find("Text").GetComponent<Text>().text = "x" + contentsMap.Value.ToString();
                    storage.SetActive(true);
                    break;
                case Stair sta:
                    var stair = _hints.transform.Find("Stair").gameObject;
                    stair.transform.Find("Text").GetComponent<Text>().text = "x" + contentsMap.Value.ToString();
                    stair.SetActive(true);
                    break;
            }
        }

        public void ShowContents(ITileContent contents)
        {
            _contents.GetComponent<Image>().sprite = contents.Image;
            _contents.SetActive(true);
        }

        public void ChangeBad()
        {
            _bad.SetActive(!_bad.activeSelf);
        }
    }
}