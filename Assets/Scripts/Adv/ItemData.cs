using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv.Effects;

namespace Adv
{    
    [CreateAssetMenu(fileName = "ItemData", menuName = "SweepAdvencher/ItemData", order = 0)]
    public class ItemData : ScriptableObject, IHaveRarity
    {
        [SerializeField]
        private Sprite _image;
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _info;
        [SerializeField]
        private List<Effect> _effect;
        [SerializeField]
        private float _rarity;
        public Sprite Image{ get { return _image; } }
        public string ID{ get { return _id; } }
        public string Name{ get { return _name; } }
        public string Info{ get { return _info; } }
        public IEnumerable<Effect> Effect{ get { return _effect; } }
        public float Rarity{ get { return _rarity; } }
    }
}