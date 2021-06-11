using UnityEngine;
using Adv;

namespace UI.Orders
{    
    [CreateAssetMenu(fileName = "LoadStageOrder", menuName = "AdvSweeper/Order/LoadStageOrder", order = 0)]
    public class LoadStageOrder : ScriptableObject, IOrder 
    {
        public StageData Data;

        public void Reset()
        {
            Data = null;
        }
    }
}