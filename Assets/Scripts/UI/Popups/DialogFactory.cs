using UnityEngine;

namespace UI.Popups
{
    public class DialogFactory : Factory<GameObject>
    {
        public DialogFactory()
        {
            _original = Resources.Load("Prefabs/Dialog") as GameObject;
        }
    }
}