using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typePoolObject {obstacle, turbo, coin }
public class PoolObject : MonoBehaviour
{
    public PlayerController playerController;
    public Pool myPool;
    public typePoolObject mytype;

    private void Start()
    {
        setObjectPool(myPool);
    }
    void Update()
    {
        devolverAlPool();
    }
    public void devolverAlPool()
    {
        if (this.transform.TransformPoint(this.transform.position).z < -1)
        {
            myPool.guardarPoolObject(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (mytype.Equals(typePoolObject.coin))
            {
                playerController.add1Coin();
                Debug.Log("chocamoscon coin");
            }

            else if (mytype.Equals(typePoolObject.turbo))
            {
                playerController.add1turbo();
                Debug.Log("chocamoscon turbo");
            }

            else if (mytype.Equals(typePoolObject.obstacle)) 
            {
                GameManager.instance.gameOver();
            }

            myPool.guardarPoolObject(this);
        }
    }
    public void setObjectPool(Pool myPool) 
    {
        this.myPool = myPool;
    }
}
