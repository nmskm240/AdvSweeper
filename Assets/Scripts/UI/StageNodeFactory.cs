using UnityEngine;

namespace UI
{
    public class StageNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/StageNode") as GameObject);
        }
    }
}