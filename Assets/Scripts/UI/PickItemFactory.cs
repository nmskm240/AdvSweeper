using UnityEngine;

namespace UI
{
    public class PickItemFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/PickItem") as GameObject);
        }
    }
}