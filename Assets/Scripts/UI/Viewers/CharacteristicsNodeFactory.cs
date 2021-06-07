using UnityEngine;

namespace UI.Viewers
{
    public class CharacteristicsNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/CharacteristicsNode") as GameObject);
        }
    }
}