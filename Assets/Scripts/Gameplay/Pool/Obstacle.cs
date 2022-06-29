using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : PoolObject
{
    public float velocidad;

    void Update()
    {
        devolverAlPool();
        behaviour();
    }

    public void behaviour() 
    {
        this.transform.position += this.transform.forward*Time.deltaTime*velocidad; 
    }

    public void devolverAlPool() 
    {
        if (this.transform.TransformPoint(this.transform.position).z < -1)
        {
            myPool.guardarPoolObject(this);
        }
    }
}
