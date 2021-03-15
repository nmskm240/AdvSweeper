using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiSceneManagement
{
    public static class MultiSceneManager
    {
        private static SceneTable _sceneTable;
        private static List<SceneData> _loadedSceneDatas = new List<SceneData>();

        public static IEnumerable<SceneData> LoadedSceneDatas { get { return _loadedSceneDatas; } }

        private static Scene GetSceneOfSameCategoryInHierarchy(SceneData sceneData)
        {
            if(sceneData == null || string.IsNullOrEmpty(sceneData.Category))
            {
                return new Scene();
            }
            for(int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var data = _sceneTable.GetSceneData(scene.name);
                if(scene.name == sceneData.Name || data == null || string.IsNullOrEmpty(data.Category))
                {
                    continue;
                }
                if(data.Category == sceneData.Category)
                {
                    return scene;
                }
            }
            return new Scene();
        }

        private static void LoadSceneProcess(string sceneName)
        {
            var sceneData = _sceneTable.GetSceneData(sceneName);
            if(sceneData == null)
            {
                Debug.LogError("Unkown SceneData");
                return;
            }
            if(SceneManager.GetSceneByName(sceneName).IsValid())
            {
                Debug.LogWarning("Has already been loaded");
                return;
            }
            var sceneOfSomeCategory = GetSceneOfSameCategoryInHierarchy(sceneData);
            if(sceneOfSomeCategory.IsValid())
            {
                UnloadScene(sceneOfSomeCategory.name);
            }
            _loadedSceneDatas.Add(sceneData);
            SceneManager.LoadSceneAsync(sceneData.Name, LoadSceneMode.Additive);
        }

        private static void UnloadSceneProcess(string sceneName)
        {
            if(!SceneManager.GetSceneByName(sceneName).IsValid())
            {
                return;
            }
            var children = _sceneTable.GetChildScenes(sceneName);
            if(children != null)
            {
                foreach(var child in children)
                {
                    var childScene = SceneManager.GetSceneByName(child.Name);
                    if(childScene.IsValid())
                    {
                        UnloadSceneProcess(childScene.name);
                    }
                }
            }
            _loadedSceneDatas.Remove(_sceneTable.GetSceneData(sceneName));
            var scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.UnloadSceneAsync(scene);
        }

        public static void Init()
        {
            _sceneTable = SceneTable.Load();
        }

        public static void LoadScene(string sceneName)
        {
            LoadSceneProcess(sceneName);
        }

        public static void UnloadScene(string sceneName)
        {
            UnloadSceneProcess(sceneName);
        }

        public static bool IsLoaded(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).IsValid();
        }

        public static void UndoParentScene()
        {
            foreach (var sceneData in _loadedSceneDatas)
            {
                if(!string.IsNullOrEmpty(sceneData.ParentName))
                {
                    LoadScene(sceneData.ParentName);
                    break;
                }
            }
        }
    }
}