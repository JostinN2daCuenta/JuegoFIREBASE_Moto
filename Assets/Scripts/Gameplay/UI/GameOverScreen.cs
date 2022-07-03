using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    /*GameOvewrScreen*/
    public GameObject gameoverScreenGameObject;
    public PlayerController playerControllerReference;
    public SceneMovement SceneControllerReference;



    [SerializeField] TextMeshProUGUI kilometrosUI;
    [SerializeField] TextMeshProUGUI coinsUI;

    [SerializeField] TextMeshProUGUI kilometrosUI_record;
    [SerializeField] TextMeshProUGUI coinsUI_record;


    private void Start()
    {
        GameOverEvent.eventGameOver += llenarCamposEstadisticas;
    }


    public void llenarCamposEstadisticas()
    {
        gameoverScreenGameObject.gameObject.SetActive(true);
        int kilometrosNormal = (int)SceneControllerReference.kilometros;
        int coinsNormal = playerControllerReference.coins;

        int kilometrosNormalRecord = 555;
        int coinsNormalRecord = 23;


        updateTexts(kilometrosNormal, coinsNormal, kilometrosNormalRecord, coinsNormalRecord);
    }
    public void updateTexts(int kilometrosNormal, int coinsNormal, int kilometrosRecord, int coinsRecord) 
    {
        kilometrosUI.text = kilometrosNormal.ToString() + "km";
        coinsUI.text = coinsNormal.ToString();
        kilometrosUI_record.text = kilometrosRecord.ToString()+" km" + " record";
        coinsUI_record.text = coinsRecord.ToString()+ " record";
    }
}
