using UnityEngine;
using UnityEngine.Events;
using Adv;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "LoadStageOrder", menuName = "AdvSweeper/Order/LoadStageOrder", order = 0)]
    public class LoadStageOrder : Order 
    {
        public StageData Data;

        public override void Reset()
        {
            base.Reset();
            Data = null;
        }
    }
}