using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    public terrainGenerator referencePool;
    public Transform pivotCreationNext;

    void Update()
    {
        if (this.transform.TransformPoint(this.transform.position).z < -20)
        {
            referencePool.newPositionForBlock(this);
        }
    }
}