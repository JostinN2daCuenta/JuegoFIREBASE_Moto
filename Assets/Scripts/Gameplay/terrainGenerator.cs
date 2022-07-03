using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class terrainGenerator : MonoBehaviour
{
    public List<Content> pool;
    public Content current;

    void Start()
    {
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
}
