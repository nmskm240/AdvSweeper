using UnityEngine;

public abstract class OrderReceiveMonoBehaviour<T> : MonoBehaviour where T : ScriptableObject, IOrder
{
    [SerializeField]
    protected T _order;
}