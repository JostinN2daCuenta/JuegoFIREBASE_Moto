using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGenerator : MonoBehaviour
{
    public List<Content> pool;
    public Content current;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
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
        }
    }
}
