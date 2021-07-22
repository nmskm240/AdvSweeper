using UnityEngine;
using UnityEngine.Events;

namespace Tutorial
{    
    [CreateAssetMenu(fileName = "TutorialOrder", menuName = "AdvSweeper/Order/TutorialOrder", order = 0)]
    public class TutorialOrder : Order
    {
        public TutorialTask TutorialTask;

        public override void Reset()
        {
            base.Reset();
            TutorialTask = null;
        }
    }
}