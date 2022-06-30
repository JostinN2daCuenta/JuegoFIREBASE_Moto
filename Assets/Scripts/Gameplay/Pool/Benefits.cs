using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benefits : PoolObject
{
    public float velocidad;

    void Update()
    {
        behaviour();
        devolverAlPool();
    }

    public void behaviour()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * velocidad;
    }

    public void devolverAlPool()
    {
        if (this.transform.position.z < -1)
        {
            myPool.guardarPoolObject(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.add1turbo();
            myPool.guardarPoolObject(this);
        }
    }
}
