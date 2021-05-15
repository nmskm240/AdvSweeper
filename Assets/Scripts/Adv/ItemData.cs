using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv.Effects;
using Alchemy;

namespace Adv
{    
    [CreateAssetMenu(fileName = "ItemData", menuName = "AdvSweeper/ItemData", order = 0)]
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
        private bool _isMaterial;
        [SerializeReference, SubclassSelector]
        private List<IEffect> _effects;
        [SerializeField]
        private List<CategoryData> _categories;
        [SerializeField, Range(0.1f,100)]
        private float _rarity;

        public Sprite Image{ get { return _image; } }
        public string ID{ get { return _id; } }
        public string Name{ get { return _name; } }
        public string Info{ get { return _info; } }
        public bool IsMaterial{ get{ return _isMaterial; } }
        public int Quality{ get; set; }
        public IEnumerable<IEffect> Effects{ get { return _effects; } }
        public IEnumerable<CategoryData> Categories{ get { return _categories; } }
        public IEnumerable<CharacteristicsData> Characteristics{ get; set; }
        public float Rarity{ get { return _rarity; } }
    }
}