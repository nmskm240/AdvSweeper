using UnityEngine;
using Adv.Effects;

namespace Alchemy 
{     
    [System.Serializable, CreateAssetMenu(fileName = "CharacteristicsData", menuName = "AdvSweeper/CharacteristicsData", order = 0)]
    public class CharacteristicsData : BaseData
    {
        [SerializeReference, SubclassSelector]
        private IEffect _effect;
        [SerializeField]
        private EffectTiming _timing;

        public IEffect Effect{ get { return _effect; } }
        public EffectTiming Timing { get { return _timing; } }
    }
}