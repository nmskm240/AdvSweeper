using UnityEngine;

namespace UI.Viewers
{
    public class ItemNodeFactory : Factory<GameObject>
    {
        public ItemNodeFactory()
        {
            _original = Resources.Load("Prefabs/ItemNode") as GameObject;
        }
    }
}