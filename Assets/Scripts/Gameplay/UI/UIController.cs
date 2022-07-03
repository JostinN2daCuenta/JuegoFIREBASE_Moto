using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public SwitchControl switchControl_;

    /*PARA EL TURBO*/
    public RectTransform turboMask;
    public RectTransform TurboSprite;
    public float paraActivarTurbo;
    public float contadorTurbo;

    public PlayerController playerReference;
    public SceneMovement velocidadReference;//faaaaaaaaaaa

    /*PARA Coin*/
    public TextMeshProUGUI coins;

    public void mofifyCoinText(int coin) 
    {
        coins.text = coin.ToString();
    }
    public void llenarTurbo() 
    {
        if (playerReference.turbo < paraActivarTurbo + 1)
        {
            turboMask.localPosition += new Vector3(0, TurboSprite.rect.height / paraActivarTurbo, 0);
        }
    }
    public void vaciarTrubo() 
    {
        if (playerReference.turbo >= paraActivarTurbo)
        {
            velocidadReference.velocidadMovimiento += 50;
            contadorTurbo = 0;
            playerReference.turbo = 0;
            turboMask.localPosition = new Vector3(0, -TurboSprite.rect.height, 0);
            StartCoroutine(turboMomentaneo());
        }
        
    }

    IEnumerator turboMomentaneo()
    {
        yield return new WaitForSeconds(5);
        velocidadReference.velocidadMovimiento -= 50;
    }
}
