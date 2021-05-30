using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;
using Adv;
using Adv.Effects;
using Alchemy;

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
            foreach (var itemData in savedata.ContainerDatas)
            {
                var datas = itemData.Split(' ');
                var item = Instantiate(Resources.Load("Datas/Item/" + datas[0])) as ItemData;
                item.Quality = int.TryParse(datas[1], out var result) ? result : 0;
                foreach (var effect in datas[2].Split(','))
                {
                    if (string.IsNullOrEmpty(effect)) continue;
                    item.Effects.Add(Resources.Load("Datas/Effect/" + effect) as EffectData);
                }
                foreach (var characteristic in datas[3].Split(','))
                {
                    if (string.IsNullOrEmpty(characteristic)) continue;
                    item.Characteristics.Add(Resources.Load("Datas/Characteristic/" + characteristic) as CharacteristicsData);
                }
                container.Contents.Add(item);
            }
        }
    }
}