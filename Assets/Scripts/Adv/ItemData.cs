using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv.Effects;
using Alchemy;

namespace Adv
{    
    [System.Serializable, CreateAssetMenu(fileName = "ItemData", menuName = "AdvSweeper/ItemData", order = 0)]
    public class ItemData : AlchemyMaterial, IHaveRarity
    {
        [SerializeField]
        private bool _isMaterial;
        [SerializeField]
        private List<EffectData> _effects;
        [SerializeField]
        private List<CategoryData> _categories;
        [SerializeField, Range(0.1f,100)]
        private float _rarity;

        public bool IsMaterial{ get{ return _isMaterial; } }
        public int Quality{ get; set; }
        public int Price{ get; set; }
        public IEnumerable<EffectData> Effects{ get { return _effects; } }
        public IEnumerable<CategoryData> Categories{ get { return _categories; } }
        public IEnumerable<CharacteristicsData> Characteristics{ get; set; } = new List<CharacteristicsData>();
        public float Rarity{ get { return _rarity; } }

        public new void Copy(ItemData data)
        {
            base.Copy(data);
            _isMaterial = data.IsMaterial;
            Quality = data.Quality;
            _effects = data.Effects as List<EffectData>;
            _categories = data.Categories as List<CategoryData>;
            Characteristics = data.Characteristics as List<CharacteristicsData>;
        }

        public override string ToString()
        {
            var effectIDs = "";
            var characteristicIDs = "";
            foreach(var effect in Effects)
            {
                effectIDs += effect.ID + ","; 
            }
            foreach(var characteristic in Characteristics)
            {
                characteristicIDs += characteristic.ID + ",";
            }
            return ID + " " + Quality + " " + effectIDs + " " + characteristicIDs;
        }
    }
}