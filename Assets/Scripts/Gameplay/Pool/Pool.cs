using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public string poolNane;

    public PlayerController playerController;
    public List<PoolObject> prefabPoolObjects;
    public List<PoolObject> pool;
    public Vector2 posRandom;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void fullStartPool(int cantidadInicial)
    {
        PoolObject tmp;
        for (int i = 0; i < cantidadInicial; i++)
        {
            tmp = Instantiate(prefabPoolObjects[Random.Range(0, prefabPoolObjects.Count)], this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y), 0, 0), prefabPoolObjects[0].transform.rotation);
            pool.Add(tmp);
            tmp.setObjectPool(this);
            tmp.transform.SetParent(this.transform);
            tmp.gameObject.SetActive(false);
        }
    }

    public void guardarPoolObject(PoolObject objetcttt)
    {
        objetcttt.gameObject.SetActive(false);
        objetcttt.transform.position = this.transform.position;
        pool.Add(objetcttt);
    }
    public void getObject()
    {
        PoolObject tmp;

        if (pool.Count == 0)
        {
            PoolObject temp = prefabPoolObjects[Random.Range(0, prefabPoolObjects.Count)];
            tmp = Instantiate(temp, this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y), 0, 0), temp.transform.rotation);
            tmp.playerController = playerController;
            tmp.setObjectPool(this);
            tmp.gameObject.SetActive(true);
            pool.Remove(tmp);
        }
        else
        {
            tmp = pool[0];
            tmp.playerController = playerController;
            tmp.transform.position = this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y), 0, 0);
            pool.Remove(tmp);
            tmp.gameObject.SetActive(true);
        }
    }
}
