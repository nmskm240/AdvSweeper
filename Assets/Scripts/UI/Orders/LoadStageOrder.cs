using UnityEngine;
using UnityEngine.Events;
using Adv;
using UI;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "LoadStageOrder", menuName = "AdvSweeper/Order/LoadStageOrder", order = 0)]
    public class LoadStageOrder : Order 
    {
        public StageData Data;

        public void DataSet(StageNode node)
        {
            Data = node.Data;
        }

        public override void Reset()
        {
            base.Reset();
            Data = null;
        }
    }
}