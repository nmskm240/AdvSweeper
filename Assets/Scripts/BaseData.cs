using UnityEngine;

[System.Serializable]
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

    public virtual void Copy(BaseData data)
    {
        _id = data.ID;
        _name = data.Name;
        _info = data.Info;
        _image = data.Image;
    }
}