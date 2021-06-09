using UnityEngine;

namespace UI
{
    public class RecipeNodeFactory : Factory<GameObject>
    {
        public RecipeNodeFactory()
        {
            _original = Resources.Load("Prefabs/RecipeNode") as GameObject;
        }
    }
}