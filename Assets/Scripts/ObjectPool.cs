using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetFromPool()
    {
        GameObject obj = transform.GetChild(0).gameObject;
        obj.transform.SetParent(null);
        return obj;
    }

    public void AddToPool(GameObject obj)
    {
        obj.transform.SetParent(transform);
    }
}
