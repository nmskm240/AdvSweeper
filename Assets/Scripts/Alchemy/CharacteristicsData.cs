using UnityEngine;

namespace Alchemy 
{     
    [CreateAssetMenu(fileName = "CharacteristicsData", menuName = "AdvSweeper/CharacteristicsData", order = 0)]
    public class CharacteristicsData : ScriptableObject 
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;

        public string ID;
        public string Name;
    }
}