using UnityEngine;

namespace Alchemy
{
    [System.Serializable]
    public class MaterialAndQuantity
    {
        [SerializeField]
        private ScriptableObject _material;
        [SerializeField]
        private int _quantity = 1;

        public ScriptableObject Material{ get { return _material; } }
        public int Quantity{ get { return _quantity; } }
    }
}