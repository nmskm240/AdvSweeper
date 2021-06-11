using UnityEngine;

namespace Adv.Effects
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "AdvSweeper/EffectData", order = 0)]
    public class EffectData : BaseData
    {
        [SerializeReference, SubclassSelector]
        private IEffect _effect;
        [SerializeField]
        private EffectTiming _timing;

        public IEffect Effect { get { return _effect; } }
        public EffectTiming Timing { get { { return _timing; } } }
    }
}