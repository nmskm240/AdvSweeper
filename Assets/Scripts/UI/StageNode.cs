using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Adv;

namespace UI
{    
    public class StageNode : MonoBehaviour
    {
        [SerializeField]
        private Text _text;
        [SerializeField]
        private StageData _stageData;

        public string Name{ get { return _text.text; } set { _text.text = value; } }

        public void Load()
        {
            var loadData = Instantiate(Resources.Load("Datas/Stage/" + Name) as StageData);
            _stageData.SetName(loadData.Name);
            _stageData.SetFloor(loadData.Floor);
            _stageData.SetSpawnTable(new List<EnemyData>(loadData.SpawnTable));
            _stageData.SetItemTable(new List<ItemData>(loadData.ItemTable));
            SceneManager.LoadScene("Game");
        }
    }
}