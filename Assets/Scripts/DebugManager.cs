using UnityEngine;
using Adv;

public class DebugManager : MonoBehaviour 
{
    [SerializeField]
    private ItemCollection _container;
    [SerializeField]
    private ItemData _item;

    private void OnGUI() 
    {
        if(GUI.Button(new Rect(0,0,100,20), "create"))
        {
            _item.Quality = UnityEngine.Random.Range(0,100);
            _container.Contents.Add(ScriptableObject.Instantiate(_item));
        }
    }
}