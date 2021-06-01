using System.Collections.Generic;
using UnityEngine;

namespace Alchemy
{
    [CreateAssetMenu(fileName = "CharacteristicsTree", menuName = "AdvSweeper/CharacteristicsTree", order = 0)]
    public class CharacteristicsTree : ScriptableObject
    {
        [SerializeField]
        private List<Synthesizer<CharacteristicsData, CharacteristicsData>> _nodes = new List<Synthesizer<CharacteristicsData, CharacteristicsData>>();

        public IEnumerable<Synthesizer<CharacteristicsData, CharacteristicsData>> Nodes { get { return _nodes; } }
    }
}