using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "EnemyData", menuName = "AdvSweeper/EnemyData", order = 0)]
    public class EnemyData : BaseData
    {
        [SerializeField]
        private int _attack;
        [SerializeField]
        private List<ItemData> _dropTable;

        public int Attack{ get { return _attack; } }
        public IEnumerable<ItemData> DropTable{ get { return _dropTable; } }
    }
}