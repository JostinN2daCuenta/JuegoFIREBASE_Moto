using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class terrainGenerator : MonoBehaviour
{
    public List<Content> pool;
    public Content current;
    public float velocidadMovimiento;




    /*UI KILOMETROS, SE PODRIA USAR OTRA CLASE PERO BOE*/
    public float kilometros;
    public TextMeshProUGUI kilometrosText;
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
        kilometros += Time.deltaTime * velocidadMovimiento/50;
        kilometrosText.text = kilometros.ToString() + " km";
        this.transform.position -= this.transform.forward * Time.deltaTime * velocidadMovimiento;
    }

    IEnumerator increaseVelocity()
    {
        velocidadMovimiento += 3;
        yield return new WaitForSeconds(10);
        StartCoroutine(increaseVelocity());
    }


}
