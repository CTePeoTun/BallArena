using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class GameObjectPool<T> : MonoBehaviour where T : PooledGameObject
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }

    [SerializeField] private PoolType poolType;
    [SerializeField] private bool collectionChecks = true;
    [SerializeField] private int startPoolSize = 10;
    [SerializeField] private int maxPoolSize = 20;
    [SerializeField] private T prefab;

    private IObjectPool<PooledGameObject> pool;

    private void Awake()
    {
        if (pool == null)
        {
            if (poolType == PoolType.Stack)
                pool = new ObjectPool<PooledGameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
            else
                pool = new LinkedPool<PooledGameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
        }
        for (int i = 0; i < startPoolSize; i++)
        {
            var go = CreatePooledItem();
            go.ReturnToPool();
        }
    }

    public int CountInactive => throw new System.NotImplementedException();

    private PooledGameObject CreatePooledItem()
    {
        PooledGameObject obj = Instantiate(prefab, this.transform);
        obj.Create((IObjectPool<PooledGameObject>)pool);
        return obj;
    }

    protected virtual void OnReturnedToPool(PooledGameObject obj)
    {
        obj.Clear();
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(this.transform);
    }

    protected virtual void OnTakeFromPool(PooledGameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnDestroyPoolObject(PooledGameObject obj)
    {
        Destroy(obj.gameObject);
    }

    public T Get()
    {
        return (T) pool.Get();
    }

}
