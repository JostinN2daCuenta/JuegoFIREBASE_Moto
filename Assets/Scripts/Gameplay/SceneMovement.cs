using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneMovement : MonoBehaviour
{
    public float kilometros;
    public TextMeshProUGUI kilometrosText;
    public float velocidadMovimiento;
    void Start()
    {
        GameOverEvent.eventGameOver += myGameOver;
        //StartCoroutine(increaseVelocity());
    }
    void Update()
    {
        if (!GameManager.instance.gameOverVariable) 
        {
            kilometros += Time.deltaTime * velocidadMovimiento / 100;
            kilometrosText.text = kilometros.ToString("0.##") + " km";
            this.transform.position -= this.transform.forward * Time.deltaTime * velocidadMovimiento;
        }
        
    }


    IEnumerator increaseVelocity()
    {
        velocidadMovimiento += 3;
        yield return new WaitForSeconds(10);
        StartCoroutine(increaseVelocity());
    }

    public void myGameOver() 
    {
        velocidadMovimiento = 0;
    }
}
