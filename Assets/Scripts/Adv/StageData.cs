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
        public IEnumerable<EnemyData> SpawnTable{ get { return _spawnTable; } }
        public IEnumerable<ItemData> ItemTable{ get { return _itemTable; } }

        public void SetName(string name){ _name = name; }
        public void SetFloor(int floor){ _floor = floor; }
        public void SetSpawnTable(List<EnemyData> spawnTable){ _spawnTable = spawnTable; }
        public void SetItemTable(List<ItemData> itemTable){ _itemTable = itemTable; }

        public IEnumerable<EnemyData> LottoSpawnTable(int count)
        {
            var spawnTable = new List<EnemyData>();
            for(int i = 0; i < count; i++)
            {
                spawnTable.Add(RandomWithWeight.Lotto<EnemyData>(_spawnTable));
            }
            return SpawnTable;
        }

        public IEnumerable<ItemData> LottoItemTable(int count)
        {
            var itemTable = new List<ItemData>();
            for(int i = 0; i < count; i ++)
            {
                itemTable.Add(RandomWithWeight.Lotto<ItemData>(_itemTable));
            }
            return ItemTable;
        }
    }
}