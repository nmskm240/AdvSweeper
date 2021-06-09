using UnityEngine;

namespace UI.Counters
{
    public class  ContentsCounterFactory : Factory<GameObject>
    {
        public ContentsCounterFactory()
        {
            _original = Resources.Load("Prefabs/ContentsCounter") as GameObject;
        }
    }
}