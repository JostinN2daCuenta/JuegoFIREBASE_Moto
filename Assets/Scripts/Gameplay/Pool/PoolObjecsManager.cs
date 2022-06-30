using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjecsManager : MonoBehaviour
{
    public Pool poolElementosBeneficios;
    public float cooldownElementosBeneficiosos;

    public Pool poolElementosObstaculos;
    public float cooldownElementosObstaculos;

    public float cont1;
    public float cont2;
    void Start()
    {
        cooldownElementosBeneficiosos = 15;
        cooldownElementosObstaculos = 2;

        poolElementosBeneficios.getObject();
        poolElementosObstaculos.getObject();
    }

    private void Update()
    {
        cont1 += Time.deltaTime;
        if (cont1 > cooldownElementosBeneficiosos) 
        {
            poolElementosBeneficios.getObject();
            cont1 = 0;
        }

        cont2 += Time.deltaTime;
        if (cont2 > cooldownElementosObstaculos)
        {
            poolElementosObstaculos.getObject();
            cont2 = 0;
        }
    }

    /*public IEnumerator getPoolObject(Pool pool, Vector2 timeRange) 
    {
        float temp = Random.Range(timeRange.x, timeRange.y);
        pool.getObject();
        yield return new WaitForSeconds(temp);
        StartCoroutine(getPoolObject(pool, timeRange));
    }*/

}
