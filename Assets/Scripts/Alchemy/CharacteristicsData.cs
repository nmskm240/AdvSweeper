using UnityEngine;
using Adv.Effects;

namespace Alchemy 
{     
    [CreateAssetMenu(fileName = "CharacteristicsData", menuName = "AdvSweeper/CharacteristicsData", order = 0)]
    public class CharacteristicsData : BaseData
    {
        [SerializeReference, SubclassSelector]
        private IEffect _effect;
    }
}