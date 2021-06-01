using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RandomWithWeights;
using Sweeper.TileContents;
using Alchemy;
using Adv;
using UI;

namespace Sweeper
{
    public class Stage : MonoBehaviour
    {
        [SerializeField]
        private int _viewSize = 600;
        [SerializeField]
        private GridLayoutGroup _gridLayputGroup;
        [SerializeField]
        private StageInfo _info;
        [SerializeField]
        private StageData _stageData;

        public GameObject[,] Map { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int NowFloor { get; private set; } = 0;

        private void Awake()
        {
            Next();
        }

        public void Create(int width, int height, StageOption stageOption)
        {
            if (width <= 0 || height <= 0)
            {
                Debug.LogError("width,　height は1以上にする必要があります。");
                width = (width <= 0) ? 4 : width;
                height = (height <= 0) ? 4 : height;
            }
            Reset(width, height);
            foreach (var obj in Map)
            {
                var tile = obj.GetComponent<Tile>();
                var pos = tile.Pos;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        var x = (int)pos.x + j;
                        var y = (int)pos.y + i;
                        if ((i == 0 && j == 0) || !(0 <= x && x < Width) || !(0 <= y && y < Height))
                        {
                            continue;
                        }
                        tile.AddAroundTile(Map[y, x].GetComponent<Tile>());
                    }
                }
            }
            foreach (var enemy in stageOption.SpawnTable)
            {
                SetContents(new Enemy(enemy));
            }
            for (int i = 0; i < stageOption.PickPoint; i++)
            {
                var items = new List<ItemData>();
                var value = UnityEngine.Random.Range(1, 5);
                foreach (var data in RandomWithWeight.Lottos<ItemData>(_stageData.ItemTable, value))
                {
                    var item = ScriptableObject.Instantiate(data);
                    var characteristics = RandomWithWeight.Lottos<CharacteristicsData>(_stageData.CharacteristicsTable, UnityEngine.Random.Range(0, 3));
                    item.Quality = (int)_stageData.QualityRange.randomValue;
                    item.Init(characteristics.Distinct(new ObjectCompare<CharacteristicsData>()));
                    items.Add(item);
                }
                SetContents(new Pick(items));
            }
            if (NowFloor < _stageData.Floor)
            {
                SetContents(new Stair());
            }
            else
            {
                SetContents(new Exit());
            }
            _info.ShowContents(stageOption);
            _info.SetFloor(_stageData.Name + NowFloor + "F");
            _info.SetTimer(stageOption.Openable);
        }

        private void Clear()
        {

        }

        private void Reset(int width, int height)
        {
            foreach (Transform tf in transform)
            {
                Destroy(tf.gameObject);
            }
            var factory = new TileFactory();
            Map = new GameObject[height, width];
            Width = width;
            Height = height;
            _gridLayputGroup.cellSize = new Vector2(600 / Width, 600 / Width);
            _gridLayputGroup.constraintCount = Width;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var obj = factory.Create();
                    var tile = obj.GetComponent<Tile>();
                    tile.Pos = new Vector2(j, i);
                    Map[i, j] = obj;
                    obj.transform.SetParent(transform);
                    obj.transform.localScale = Vector3.one;
                }
            }
        }

        public void SetContents(ITileContents contents, int index = 1)
        {
            for (int i = 0; i < index; i++)
            {
                var x = UnityEngine.Random.Range(0, Width);
                var y = UnityEngine.Random.Range(0, Height);
                var tile = Map[y, x].GetComponent<Tile>();
                if (tile.Contents.GetType() != typeof(None))
                {
                    i--;
                    continue;
                }
                tile.Contents = contents;
                tile.CountUpAroundTiles(contents);
            }
        }

        public void Next()
        {
            var size = UnityEngine.Random.Range(4, 7);
            var enemy = (int)(Mathf.Pow(size, 2) * _stageData.SpawnRate);
            var pickPoint = UnityEngine.Random.Range(1, 3);
            var option = new StageOption()
            {
                Enemy = enemy,
                PickPoint = pickPoint,
                Openable = (int)(Mathf.Pow(size, 2) * _stageData.OpenableRate),
                SpawnTable = RandomWithWeight.Lottos<EnemyData>(_stageData.SpawnTable, enemy),
            };
            NowFloor++;
            Create(size, size, option);
        }
    }
}