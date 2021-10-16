using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : Component, IPoolable
{
    private Queue<T> _inactive = new Queue<T>();
    [SerializeField] protected GameObject _prefab;
    public static Pool<T> Instance { get; private set; }

    public void Enpool(T t)
    {
        _inactive.Enqueue(t);
        t.pooled = true;
    }
    public T Depool()
    {
        T t;
        if (_inactive.Count >= 1) t = _inactive.Dequeue();
        else t = Instantiate(_prefab).GetComponent<T>();
        t.pooled = false;
        return t;
    }
    private void Awake()
    {
        Instance = this;
    }
}
