using UnityEngine;
using Adv;

public class DebugManager : MonoBehaviour 
{
    [SerializeField]
    private ItemCollection _container;
    [SerializeField]
    private ItemData _water;

    private void OnGUI() 
    {
        if(GUI.Button(new Rect(0,0,100,20), "create"))
        {
            _water.Quality = UnityEngine.Random.Range(0,100);
            _container.Contents.Add(_water);
        }
    }
}