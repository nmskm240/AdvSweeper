using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adv.Effects;
using Alchemy;

namespace Adv
{    
    [System.Serializable, CreateAssetMenu(fileName = "ItemData", menuName = "AdvSweeper/ItemData", order = 0)]
    public class ItemData : AlchemyMaterial
    {
        [SerializeField]
        private bool _isMaterial;
        [SerializeField]
        private List<EffectData> _effects;
        [SerializeField]
        private List<CategoryData> _categories;

        public bool IsMaterial{ get{ return _isMaterial; } }
        public int Quality{ get; set; }
        public int Price{ get; set; }
        public List<EffectData> Effects{ get { return _effects; } }
        public List<CategoryData> Categories{ get { return _categories; } }
        public List<CharacteristicsData> Characteristics{ get; set; } = new List<CharacteristicsData>();

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
            var characteristicIDs = "";
            foreach(var characteristic in Characteristics)
            {
                characteristicIDs += characteristic.ID + ",";
            }
            return ID + " " + Quality + " " + characteristicIDs;
        }
    }
}