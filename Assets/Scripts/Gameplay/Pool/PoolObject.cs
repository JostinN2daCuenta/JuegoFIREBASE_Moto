using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PlayerController playerController;
    public Pool myPool;

    public void setObjectPool(Pool myPool) 
    {
        this.myPool = myPool;
    }
}
