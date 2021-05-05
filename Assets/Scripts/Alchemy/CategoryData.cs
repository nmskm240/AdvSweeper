using UnityEngine;

namespace Alchemy
{    
    [CreateAssetMenu(fileName = "CategoryData", menuName = "AdvSweeper/CategoryData", order = 0)]
    public class CategoryData : ScriptableObject 
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;

        public string ID{ get { return _id; } }
        public string Name{ get { return _name; } }
    }
}