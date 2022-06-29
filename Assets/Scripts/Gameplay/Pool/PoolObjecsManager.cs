using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjecsManager : MonoBehaviour
{
    public Pool poolElementosBeneficios;
    public Vector2 cooldownElementosBeneficiosos;

    public Pool poolElementosObstaculos;
    public Vector2 cooldownElementosObstaculos;
    void Start()
    {
        StartCoroutine(getPoolObject(poolElementosObstaculos, cooldownElementosObstaculos));
    }

    public IEnumerator getPoolObject(Pool pool, Vector2 timeRange) 
    {
        float temp = Random.Range(timeRange.x, timeRange.y);
        pool.getObject();
        yield return new WaitForSeconds(temp);
        StartCoroutine(getPoolObject(pool, timeRange));
    }
}
