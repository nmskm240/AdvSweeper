using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{    
    [CreateAssetMenu(fileName = "TutorialTask", menuName = "AdvSweeper/TutorialTask", order = 0)]
    public class TutorialTask : ScriptableObject 
    {
        [SerializeReference, SubclassSelector]
        private List<ITask> _tasks = new List<ITask>();

        public IEnumerable<ITask> Tasks { get { return _tasks; } }
    }
}