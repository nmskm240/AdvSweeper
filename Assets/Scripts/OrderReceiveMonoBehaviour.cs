using UnityEngine;

public abstract class OrderReceiveMonoBehaviour<T> : MonoBehaviour where T : Order
{
    [SerializeField]
    protected T _order;
}