using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject terrain;
    public string poolNane;

    public PlayerController playerController;
    public List<PoolObject> prefabPoolObjects;
    public List<PoolObject> pool;
    public Vector2 posRandom;

    public float cont1;
    public float cooldown;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        GameOverEvent.eventGameOver += myGameOver;
    }

    private void Update()
    {
        if (pool.Count > 0) 
        {
            cont1 += Time.deltaTime;
            if (cont1 > cooldown)
            {
                getObject();
                cont1 = 0;
            }
        }

    }

    public void guardarPoolObject(PoolObject objetcttt)
    {
        pool.Add(objetcttt);
        objetcttt.gameObject.SetActive(false);
        objetcttt.transform.SetParent(this.transform);
        objetcttt.transform.position = this.transform.position;
    }
    public void getObject()
    {
        PoolObject tmp;

        /*if (pool.Count == 0)
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
        }*/


        if (pool.Count > 0)
        {
            tmp = pool[Random.Range(0,pool.Count-1)];
            pool.Remove(tmp);
            tmp.playerController = playerController;
            tmp.transform.position = this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y), 0, 0);
            tmp.gameObject.SetActive(true);
            tmp.transform.SetParent(terrain.transform);
        }

    }

    public void myGameOver()
    {
        this.gameObject.SetActive(false);
    }

    /*public void fullStartPool(int cantidadInicial)
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
    }*/

}
