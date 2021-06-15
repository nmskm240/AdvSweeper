using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomWithWeights;
using Alchemy;

namespace Adv
{
    [CreateAssetMenu(fileName = "StageData", menuName = "AdvSweeper/StageData", order = 0)]
    public class StageData : BaseData
    {
        [SerializeField]
        private int _floor = 1;
        [SerializeField, Range(0f, 0.3f)]
        private float _spawnRate = 0.15f;
        [SerializeField, Range(0f, 0.3f)]
        private float _pickRate = 0.15f;
        [SerializeField, Range(0f, 1f)]
        private float _openableRate = 0.75f;
        [SerializeField]
        private List<WeightNode<EnemyData>> _spawnTable = new List<WeightNode<EnemyData>>();
        [SerializeField]
        private List<WeightNode<ItemData>> _itemTable = new List<WeightNode<ItemData>>();
        [SerializeField]
        private List<WeightNode<CharacteristicsData>> _characteristicsTable = new List<WeightNode<CharacteristicsData>>();
        [SerializeField, MinMaxRange(0, 999)]
        private MinMax _qualityRange;

        public int Floor { get { return _floor; } }
        public float SpawnRate { get { return _spawnRate; } }
        public float PickRate { get { return _pickRate; } }
        public float OpenableRate { get { return _openableRate; } }
        public IEnumerable<WeightNode<EnemyData>> SpawnTable { get { return _spawnTable; } }
        public IEnumerable<WeightNode<ItemData>> ItemTable { get { return _itemTable; } }
        public IEnumerable<WeightNode<CharacteristicsData>> CharacteristicsTable { get { return _characteristicsTable; } }
        public MinMax QualityRange { get { return _qualityRange; } }
    }
}