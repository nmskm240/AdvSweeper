using UnityEngine;
using Adv;

namespace Sweeper.TileContents
{
    public class Enemy : ITileContent
    {
        private Sprite _image;
        private EnemyData _data;

        public Sprite Image{ get { return _image; } }

        public Enemy(EnemyData data)
        {
            _image = data.Image;
            _data = data;
        }

        public void Open()
        {
            Debug.Log(_data.Name + "に遭遇した");
        }
    }
}