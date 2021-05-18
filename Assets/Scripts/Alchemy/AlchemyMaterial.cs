using UnityEngine;

namespace Alchemy
{    
    public class AlchemyMaterial : ScriptableObject 
    {    
        [SerializeField]
        private Sprite _image;

        public Sprite Image{ get { return _image; } }
    }
}