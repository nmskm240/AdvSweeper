using UnityEngine;

namespace UI.Popups
{
    public class DialogFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/Dialog") as GameObject);
        }
    }
}