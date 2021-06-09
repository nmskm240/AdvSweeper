using UnityEngine;

namespace UI.Viewers
{
    public class CharacteristicsNodeFactory : Factory<GameObject>
    {
        public CharacteristicsNodeFactory()
        {
            _original = Resources.Load("Prefabs/CharacteristicsNode") as GameObject;
        }
    }
}