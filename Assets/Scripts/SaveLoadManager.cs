using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;
using Adv;

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
        while(true)
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
            _data = JsonUtility.FromJson<SaveData>(data);
            foreach(var itemData in _data.ContainerDatas)
            {
                var datas = itemData.Split(' ');
                var item = Instantiate(Resources.Load("Datas/Item/" + datas[0])) as ItemData;
                item.Quality = int.Parse(datas[1]);
                foreach(var effect in datas[2].Split(','))
                {
                    item.Effects.Append(Resources.Load("Datas/Effect/" + effect));
                }
                foreach(var characteristic in datas[3].Split(','))
                {
                    item.Characteristics.Append(Resources.Load("Datas/Characteristics/" + characteristic));
                }
                container.Contents.Add(item);
            }
        }
    }
}