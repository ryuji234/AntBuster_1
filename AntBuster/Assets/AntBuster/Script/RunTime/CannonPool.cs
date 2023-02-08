using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPool : MonoBehaviour
{
    public Canvas canvas;
    public static CannonPool Instance;
    public int ObjectNumber;
    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<BasicCannonControl> poolingObjectQueue = new Queue<BasicCannonControl>();

    private void Awake()
    {
        Instance = this;

        Initialize(ObjectNumber);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private BasicCannonControl CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<BasicCannonControl>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public BasicCannonControl GetObject()
    {

        if (Instance.poolingObjectQueue.Count > 0)
        {
            
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(canvas.transform);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //var newObj = Instance.CreateNewObject();
            //newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);
            return null;
        }

    }

    public static void ReturnObject(BasicCannonControl obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
