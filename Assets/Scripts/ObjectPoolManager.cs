using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool
{
    public string name;
    public int size { get; }

    private Queue<GameObject> objects;

    bool init = false;

    public ObjectPool(string _name, int _size, GameObject _obj)
    {
        name = _name;
        size = _size;

        objects = new Queue<GameObject>();

        for (int i = 0; i < _size; i++)
            PoolObject(CreateObject(_obj), true);

        init = true;
    }

    private GameObject CreateObject(GameObject _obj)
    {
        GameObject obj = GameObject.Instantiate(_obj);
        return obj;
    }

    public GameObject GetObject()
    {
        if (!init)
        {
            Debug.LogError("Attempting to get from an ininitialized object pool!");
            return null;
        }

        var obj = objects.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void PoolObject(GameObject obj, bool onInit = false)
    {
        if (!init && !onInit)
        {
            Debug.LogError("Attempting to pool to an ininitialized object pool!");
            return;
        }

        objects.Enqueue(obj);
        obj.SetActive(false);
    }

    public int Count()
    {
        return objects.Count;
    }

    public void DestroyPool()
    {
        foreach (GameObject obj in objects)
            GameObject.Destroy(obj);

        objects.Clear();
    }
}

public class ObjectPoolManager// : MonoBehaviour
{
    private static ObjectPoolManager poolManager;
    public static ObjectPoolManager GetManager()
    {
        if (poolManager == null)
            poolManager = new ObjectPoolManager();

        return poolManager;
    }

    private ObjectPoolManager()
    {
        pools = new List<ObjectPool>();
    }
    private List<ObjectPool> pools;

    public ObjectPool GetPool(string name)
    {
        List<ObjectPool> foundPools = GetManager().pools.Where(pool => pool.name == name).ToList();

        if (foundPools.Count() < 0)
        {
            Debug.LogError("Attempting to access a pool that doesn't exist!");
            return null;
        }

        return foundPools[0];
    }

    public ObjectPool InitPool(string name, int size, GameObject obj)
    {
        List<ObjectPool> foundPools = GetManager().pools.Where(pool => pool.name == name).ToList();

        if (foundPools.Count() > 0)
        {
            Debug.LogError("Attempting to create a pool with the same name as another!");
            return null;
        }

        ObjectPool op = new ObjectPool(name, size, obj);
        GetManager().pools.Add(op);
        return op;
    }

    public void DestroyPool(string name)
    {
        ObjectPoolManager pm = GetManager();

        List<ObjectPool> foundPools = pm.pools.Where(pool => pool.name == name).ToList();

        if (foundPools.Count() < 0)
        {
            Debug.LogError("Attempting to destroy a pool that doesn't exist!");
            return;
        }

        foundPools[0].DestroyPool();
        pm.pools.Remove(foundPools[0]);
    }
}