using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Tutorial
{    
    public class TutorialManager : OrderReceiveMonoBehaviour<TutorialOrder>
    {
        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private TextMeshProUGUI _detail;

        private ITask _currentTask;
        private int _cursor = 0;

        private void Start()
        {
            _currentTask = _order.TutorialTask.Tasks.FirstOrDefault();
            if(_currentTask != null)
            {
                _currentTask.OnTaskStart();
            }
        }

        private void Update() 
        {
            if(_currentTask != null && _currentTask.CheckTaskComplete())
            {
                _currentTask.OnTaskComplete();
                _currentTask = _order.TutorialTask.Tasks.ElementAtOrDefault(++_cursor);
                if(_currentTask != null)
                {
                    _currentTask.OnTaskStart();
                }
            }
        }
    }
}