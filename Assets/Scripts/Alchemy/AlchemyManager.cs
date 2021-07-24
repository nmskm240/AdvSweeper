using UnityEngine;
using UI;
using UI.Orders;

namespace Alchemy
{
    public class AlchemyManager : OrderReceiveMonoBehaviour<LoadRecipeOrder>
    {
        [SerializeField]
        private Transform _materials;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
            foreach (var materialAndQuantity in _order.Data.NeedMaterials)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<MaterialNode>();
                obj.transform.SetParent(_materials);
                obj.transform.localScale = Vector3.one;
                node.Init(materialAndQuantity);
            }
        }
    }
}