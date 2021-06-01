namespace SaveSystem
{
    public interface ISavable<T>
    {
        string Serialize();
        T Deserialize(string data);
    }
}