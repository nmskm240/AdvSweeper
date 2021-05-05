using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adv
{    
    [CreateAssetMenu(fileName = "EnemyData", menuName = "AdvSweeper/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject, IHaveRarity
    {
        [SerializeField]
        private Sprite _image;
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _attack;
        [SerializeField]
        private List<ItemData> _dropTable;
        [SerializeField]
        private float _rarity;
        
        public Sprite Image{ get { return _image;} }
        public string ID { get { return _id; } }
        public string Name{ get { return _name; } }
        public int Attack{ get { return _attack; } }
        public IEnumerable<ItemData> DropTable{ get { return _dropTable; } }
        public float Rarity{ get { return _rarity; } }
    }
}