using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { derecha, izquierda, medio}
public class Content : MonoBehaviour
{
    public terrainGenerator referencePool;
    public Transform pivotCreationNext;
    public Direction direction;

    void Start()
    {

    }
    void Update()
    {
        Debug.Log(this.transform.TransformPoint(this.transform.position));
        if (this.transform.TransformPoint(this.transform.position).z < -20)
        {
            referencePool.newPositionForBlock(this);
        }
    }
}