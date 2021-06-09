using UnityEngine;

namespace UI
{
    public class PickItemFactory : Factory<GameObject>
    {
        public PickItemFactory()
        {
            _original = Resources.Load("Prefabs/PickItem") as GameObject;
        }
    }
}