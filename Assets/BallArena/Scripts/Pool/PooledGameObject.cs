using UnityEngine;
using UnityEngine.Pool;

public abstract class PooledGameObject : MonoBehaviour
{
    private IObjectPool<PooledGameObject> pool;

    public void Create(IObjectPool<PooledGameObject> pool)
    {
        this.pool = pool;
    }

    public void ReturnToPool()
    {
        pool.Release(this);
    }

    public abstract void Clear();
}
