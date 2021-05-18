using UnityEngine;

public class BaseData : ScriptableObject 
{
    [SerializeField]
    protected string _id;
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected string _info;
    [SerializeField]
    protected Sprite _image;

    public string ID{ get { return _id; } }
    public string Name{ get { return _name; } }
    public string Info{ get { return _info; } }
    public Sprite Image{ get { return _image; } }
}