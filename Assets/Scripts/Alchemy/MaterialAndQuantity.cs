using UnityEngine;

namespace Alchemy
{
    [System.Serializable]
    public class MaterialAndQuantity
    {
        [SerializeField]
        private AlchemyMaterial _material;
        [SerializeField]
        private int _quantity = 1;

        public AlchemyMaterial Material{ get { return _material; } }
        public int Quantity{ get { return _quantity; } }
    }
}