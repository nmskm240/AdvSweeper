using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        private Text _floor;

        private IFactory<GameObject> factory = new ContentsCounterFactory();

        public void SetFloor(string floorInfo)
        {
            _floor.text = floorInfo;
        }

        public void ShowContents(StageOption option)
        {
            foreach(Transform tf in _contents)
            {
                Destroy(tf.gameObject);
            }

            foreach (var contents in CountContents<EnemyData>(option.SpawnTable))
            {
                var node = factory.Create();
                var counter = node.GetComponent<ContentsCounter>();
                node.transform.SetParent(_contents);
                node.transform.localScale = Vector3.one;
                counter.Init(contents.Key, contents.Value);
            }
            for (int i = 0; i < 2; i++)
            {
                var node = factory.Create();
                var counter = node.GetComponent<ContentsCounter>();
                node.transform.SetParent(_contents);
                node.transform.localScale = Vector3.one;
                if(i == 0)
                {
                    counter.Init(Resources.Load("textures/Tile/Contents/Storage", typeof(Sprite)) as Sprite, option.ItemTable.Count());
                }
                else
                {
                    counter.Init(new Stair().Image, option.Stair);
                }
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