using UnityEngine;

public abstract class Factory<T> : Object where T : Object
{
     protected T _original;

     public T Create()
     {
          return Instantiate(_original);
     }
}