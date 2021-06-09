using UnityEngine;

namespace UI
{
    public class MaterialNodeFactory : Factory<GameObject>
    {
        public MaterialNodeFactory()
        {
            _original = Resources.Load("Prefabs/MaterialNode") as GameObject;
        }
    }
}