using UnityEngine;

namespace UI.Viewers
{
    public class EffectIconFactory : Factory<GameObject>
    {
        public EffectIconFactory()
        {
            _original = Resources.Load("Prefabs/EffectIcon") as GameObject;
        }
    }
}