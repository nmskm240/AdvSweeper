using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "StageData", menuName = "SweepAdvencher/StageData", order = 0)]
    public class StageData : ScriptableObject 
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _floor = 1;
        [SerializeField]
        private List<EnemyData> _spawnTable = new List<EnemyData>();
        [SerializeField]
        private List<ItemData> _itemTable = new List<ItemData>();

        public string Name{ get { return _name;} }
        public int Floor{ get { return _floor; } }
        public IEnumerable<EnemyData> SpawnTable{ get; private set; }
        public IEnumerable<ItemData> ItemTable{ get; private set; }

        public IEnumerable<EnemyData> LottoSpawnTable(int count)
        {
            var spawnTable = new List<EnemyData>();
            for(int i = 0; i < count; i++)
            {
                spawnTable.Add(RandomWithWeight.Lotto<EnemyData>(_spawnTable));
            }
            SpawnTable = spawnTable;
            return SpawnTable;
        }

        public IEnumerable<ItemData> LottoItemTable(int count)
        {
            var itemTable = new List<ItemData>();
            for(int i = 0; i < count; i ++)
            {
                itemTable.Add(RandomWithWeight.Lotto<ItemData>(_itemTable));
            }
            ItemTable = itemTable;
            return ItemTable;
        }
    }
}