using System.Collections;
using System.Collections.Generic;
using Adv;

namespace Sweeper
{
    public class StageOption
    {
        public int Enemy = 0;
        public int PickPoint = 0;
        public int Stair = 1;
        public int Openable = 0;
        public IEnumerable<EnemyData> SpawnTable = new List<EnemyData>();
        public IEnumerable<ItemData> ItemTable = new List<ItemData>();
    }
}