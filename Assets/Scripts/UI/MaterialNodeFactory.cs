using UnityEngine;

namespace UI
{
    public class MaterialNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/MaterialNode") as GameObject);
        }
    }
}