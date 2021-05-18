using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "EnemyData", menuName = "AdvSweeper/EnemyData", order = 0)]
    public class EnemyData : BaseData, IHaveRarity
    {
        [SerializeField]
        private int _attack;
        [SerializeField]
        private List<ItemData> _dropTable;
        [SerializeField, Range(0.1f,100)]
        private float _rarity;

        public int Attack{ get { return _attack; } }
        public IEnumerable<ItemData> DropTable{ get { return _dropTable; } }
        public float Rarity{ get { return _rarity; } }
    }
}