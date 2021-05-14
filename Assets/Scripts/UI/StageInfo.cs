using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sweeper;
using Sweeper.TileContents;
using Adv;

namespace UI
{
    public class StageInfo : MonoBehaviour
    {
        [SerializeField]
        private Transform _contents;
        [SerializeField]
        private TextMeshProUGUI _floor;
        [SerializeField]
        private ContentsCounter _timer;

        private IFactory<GameObject> factory = new ContentsCounterFactory();

        public void SetTimer(int timeLimit)
        {
            _timer.Value = timeLimit;
        }

        public void SetFloor(string floorInfo)
        {
            _floor.text = floorInfo;
        }

        public void ShowContents(StageOption option)
        {
            foreach (Transform tf in _contents)
            {
                Destroy(tf.gameObject);
            }
            foreach (var contents in CountContents<EnemyData>(option.SpawnTable))
            {
                var node = factory.Create();
                var counter = node.GetComponent<ContentsCounter>();
                node.transform.SetParent(_contents);
                node.transform.localScale = Vector3.one;
                counter.Init(contents.Key, contents.Value, true);
            }
            if(0 < option.PickPoint)
            {
                var node = factory.Create();
                var counter = node.GetComponent<ContentsCounter>();
                node.transform.SetParent(_contents);
                node.transform.localScale = Vector3.one;
                counter.Init(new Pick().Image, option.PickPoint, true);
            }
            if(0 < option.Stair)
            {
                var node = factory.Create();
                var counter = node.GetComponent<ContentsCounter>();
                node.transform.SetParent(_contents);
                node.transform.localScale = Vector3.one;
                counter.Init(new Stair().Image, option.Stair, true);
            }
        }

        private Dictionary<Sprite, int> CountContents<T>(IEnumerable<T> list)
            where T : EnemyData
        {
            var dictionary = new Dictionary<Sprite, int>();
            foreach (var contents in list)
            {
                var sprite = contents.Image;
                if (!dictionary.ContainsKey(sprite))
                {
                    dictionary.Add(sprite, 0);
                }
                dictionary[sprite]++;
            }
            return dictionary;
        }
    }
}