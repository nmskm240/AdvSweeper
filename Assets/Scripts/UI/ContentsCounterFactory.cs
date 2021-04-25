using UnityEngine;

namespace UI
{
    public class  ContentsCounterFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/ContentsCounter") as GameObject);
        }
    }
}