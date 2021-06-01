using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;
using Adv;
using Adv.Effects;
using Alchemy;

namespace SaveSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        [SerializeField]
        private SaveData _data = new SaveData();
        private string _filePath;

        private void Awake()
        {
            _filePath = Application.persistentDataPath + "/savedata.json";
        }

        private IEnumerator Start()
        {
            Load();
            yield return new WaitWhile(() => MultiSceneManager.IsLoaded("Title"));
            while (true)
            {
                yield return new WaitForSeconds(30f);
                Save();
            }
        }

        public void Save()
        {
            var json = JsonUtility.ToJson(_data, true);
            var streamWriter = new StreamWriter(_filePath);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public void Load()
        {
            if (File.Exists(_filePath))
            {
                var streamReader = new StreamReader(_filePath);
                var data = streamReader.ReadToEnd();
                var container = Resources.Load("Datas/Container") as ItemCollection;
                streamReader.Close();
                var savedata = JsonUtility.FromJson<SaveData>(data);
                container.Deserialize(savedata.ContainerData);
            }
        }
    }
}