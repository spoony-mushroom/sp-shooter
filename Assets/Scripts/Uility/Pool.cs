using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public GameObject prototype;

    private List<GameObject> pool = new List<GameObject>();

    int maxSize = 100;

    public int MaxSize
    {
        get
        {
            return maxSize;
        }

        set
        {
            maxSize = value;
        }
    }

    void Start()
    {
        Debug.Assert(prototype != null, "Pool does not have a prototype");
    }

    public T Take<T>() where T : Component
    {
        GameObject obj = null;
        var iter = pool.GetEnumerator();
        while (iter.MoveNext() && obj == null)
        {
			if (!iter.Current.activeSelf)
			{
            	obj = iter.Current;
			}
        }

        if (obj == null)
        {
            if (pool.Count < maxSize)
            {
                obj = GameObject.Instantiate(prototype);
                pool.Add(obj);
            }
            else
            {
				throw new System.OutOfMemoryException("Maximum pool size exceeded");
            }
        }

		obj.gameObject.SetActive(true);
        return obj.GetComponent<T>();
    }
}
