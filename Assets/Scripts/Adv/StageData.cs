using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "StageData", menuName = "AdvSweeper/StageData", order = 0)]
    public class StageData : BaseData 
    {
        [SerializeField]
        private int _floor = 1;
        [SerializeField, Range(0f,0.3f)]
        private float _spawnRate = 0.15f;
        [SerializeField]
        private List<EnemyData> _spawnTable = new List<EnemyData>();
        [SerializeField]
        private List<ItemData> _itemTable = new List<ItemData>();

        public int Floor{ get { return _floor; } }
        public float SpawnRate{ get { return _spawnRate; } }
        public IEnumerable<EnemyData> SpawnTable{ get { return _spawnTable; } }
        public IEnumerable<ItemData> ItemTable{ get { return _itemTable; } }

        public void Copy(StageData data)
        {
            _name = data.Name;
            _floor = data.Floor;
            _spawnRate = data.SpawnRate;
            _spawnTable = data.SpawnTable as List<EnemyData>;
            _itemTable = data.ItemTable as List<ItemData>;
        }
    }
}