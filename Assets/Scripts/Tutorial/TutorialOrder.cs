namespace Tutorial
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "TutorialOrder", menuName = "AdvSweeper/Order/TutorialOrder", order = 0)]
    public class TutorialOrder : ScriptableObject , IOrder
    {
        public TutorialTask TutorialTask;

        public void Reset()
        {
            TutorialTask = null;
        }
    }
}