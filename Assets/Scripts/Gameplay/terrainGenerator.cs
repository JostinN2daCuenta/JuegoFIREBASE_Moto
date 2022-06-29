using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGenerator : MonoBehaviour
{
    public List<Content> pool;
    public Content current;
    public float velocidadMovimiento;
    void Start()
    {
        StartCoroutine(increaseVelocity());
        foreach (Content item in pool)
        {
            item.referencePool = this;
        }
        current = pool[pool.Count - 1];
    }

    public void newPositionForBlock(Content input)
    {
        input.gameObject.transform.position = current.pivotCreationNext.transform.position;
        current = input;
    }
    void Update()
    {
        this.transform.position -= this.transform.forward * Time.deltaTime * velocidadMovimiento;
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            Content temp = Instantiate(pool[Random.Range(0, pool.Count)]);
            temp.transform.position = current.pivotCreationNext.position;

            if (current.direction == Direction.derecha)
            {
                if (temp.direction == Direction.medio)
                {
                    temp.transform.rotation = Quaternion.Euler(current.transform.rotation.eulerAngles + new Vector3(0, 180, 0));
                }
                else
                {
                    temp.transform.rotation = Quaternion.Euler(current.transform.rotation.eulerAngles + new Vector3(0, 90, 0));
                }
            }


            else if (current.direction == Direction.izquierda)
            {
                if (temp.direction == Direction.medio)
                {
                    temp.transform.rotation = current.transform.rotation;
                }
                else
                {
                    temp.transform.rotation = Quaternion.Euler(current.transform.rotation.eulerAngles - new Vector3(0, 90, 0));
                }

            }



            else if (current.direction == Direction.medio)
            {
                if (temp.direction == Direction.medio)
                {
                    temp.transform.rotation = current.transform.rotation;
                }
                else 
                {
                    temp.transform.rotation = Quaternion.Euler(current.transform.rotation.eulerAngles - new Vector3(0, 90, 0));
                }
            }
            else 
            {

            }

            current = temp;
        }*/
    }

    IEnumerator increaseVelocity()
    {
        velocidadMovimiento += 10;
        yield return new WaitForSeconds(10);
        StartCoroutine(increaseVelocity());
    }
}
