using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class OrderingManager : MonoBehaviour
{
    //singleton reference
    public static OrderingManager managerActual;
    //queue
    private Utils.PriorityQueue<IOrderable, int> functionQueue = new PriorityQueue<IOrderable, int>();
    void Awake()
    {
        managerActual = this;
    }

    void Update()
    {
        while (functionQueue.Count > 0)
        {
            IOrderable next = functionQueue.Dequeue();
            next.onStart();
        }
    }

    //adds the orderable to the queue, lower layers execute first
    public void addToStartQueue(IOrderable orderable, int layer)
    {
        functionQueue.Enqueue(orderable, layer);
    }
    
}
