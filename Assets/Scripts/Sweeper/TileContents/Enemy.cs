using UnityEngine;
using Adv;

namespace Sweeper.TileContents
{
    public class Enemy : ITileContents
    {
        private Sprite _image;
        private EnemyData _data;

        public Sprite Image{ get { return _image; } }

        public Enemy()
        {
            _image = Resources.Load("Textures/Tile/Contents/Enemy", typeof(Sprite)) as Sprite;
        }

        public Enemy(EnemyData data)
        {
            _image = data.Image;
            _data = data;
        }

        public void Open()
        {
            Debug.Log(_data.Name + "に遭遇した");
            var player = GameObject.FindWithTag("Player").GetComponent<Treasure>();
            player.Damage(_data.Attack);
        }
    }
}