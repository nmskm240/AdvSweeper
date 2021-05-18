using UnityEngine;

namespace UI
{
    public class RecipeNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/RecipeNode") as GameObject);
        }
    }
}