using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
using Adv.Effects;
using Alchemy;

namespace Adv
{
    [System.Serializable, CreateAssetMenu(fileName = "ItemData", menuName = "AdvSweeper/ItemData", order = 0)]
    public class ItemData : AlchemyMaterial, ISavable<ItemData>
    {
        [SerializeField]
        private bool _isMaterial;
        [SerializeField]
        private int _price;
        [SerializeField]
        private List<EffectData> _effects = new List<EffectData>();
        [SerializeField]
        private List<CategoryData> _categories = new List<CategoryData>();

        private List<CharacteristicsData> _characteristics = new List<CharacteristicsData>();

        public bool IsMaterial { get { return _isMaterial; } }
        public int Quality { get; set; }
        public int Price { get { return _price; } set { _price = value; } }
        public IEnumerable<EffectData> Effects { get { return _effects; } }
        public IEnumerable<CategoryData> Categories { get { return _categories; } }
        public IEnumerable<CharacteristicsData> Characteristics { get { return _characteristics; } }

        public void Init(IEnumerable<CharacteristicsData> characteristicsDatas)
        {
            _characteristics = new List<CharacteristicsData>(characteristicsDatas);
        }

        public new void Copy(ItemData data)
        {
            base.Copy(data);
            _isMaterial = data.IsMaterial;
            Quality = data.Quality;
            Price = data.Price;
            _effects = data.Effects as List<EffectData>;
            _categories = data.Categories as List<CategoryData>;
            _characteristics = data.Characteristics as List<CharacteristicsData>;
        }

        public string Serialize()
        {
            var characteristicIDs = "";
            foreach (var characteristic in Characteristics)
            {
                characteristicIDs += characteristic.ID + ",";
            }
            return ID + " " + Quality + " " + string.Join(",", Characteristics.Select(c => c.ID));
        }

        public ItemData Deserialize(string data)
        {
            Debug.Log(data);
            var datas = data.Split(' ');
            var item = Instantiate(Resources.Load("Datas/Item/" + datas[0])) as ItemData;
            var characteristics = new List<CharacteristicsData>();
            item.Quality = int.TryParse(datas[1], out var result) ? result : 0;
            foreach (var characteristic in datas[2].Split(','))
            {
                if (string.IsNullOrEmpty(characteristic)) continue;
                characteristics.Add(Resources.Load("Datas/Characteristic/" + characteristic) as CharacteristicsData);
                Debug.Log(characteristic);
            }
            item.Init(characteristics);
            return item;
        }
    }
}