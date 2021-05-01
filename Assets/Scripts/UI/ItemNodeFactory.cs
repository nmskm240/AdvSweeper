using UnityEngine;

namespace UI
{
    public class ItemNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/ItemNode") as GameObject);
        }
    }
}