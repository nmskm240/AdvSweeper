using UnityEngine;

namespace UI.Viewers
{
    public class EffectIconFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/EffectIcon") as GameObject);
        }
    }
}