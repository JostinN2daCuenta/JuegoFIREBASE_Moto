using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOverScreen : MonoBehaviour
{
    public float[] arrayDatosPlayer;
    /*GameOvewrScreen*/
    public GameObject gameoverScreenGameObject;
    public PlayerController playerControllerReference;
    public SceneMovement SceneControllerReference;
    public DataBaseManager dataBaseManager;



    [SerializeField] TextMeshProUGUI kilometrosUI;
    [SerializeField] TextMeshProUGUI coinsUI;

    [SerializeField] TextMeshProUGUI kilometrosUI_record;
    [SerializeField] TextMeshProUGUI coinsUI_record;


    private void Start()
    {
        arrayDatosPlayer = new float[2];
        GameOverEvent.eventGameOver += llenarCamposEstadisticas;
    }

    private void Update()
    {

    }
    public void llenarCamposEstadisticas()
    {
        dataBaseManager.sendData(SceneControllerReference.kilometros, playerControllerReference.coins);

        gameoverScreenGameObject.gameObject.SetActive(true);

        int kilometrosNormal = (int)SceneControllerReference.kilometros;
        int coinsNormal = playerControllerReference.coins;

        int kilometrosNormalRecord = (int)dataBaseManager.kilometosRecord;
        int coinsNormalRecord = (int)dataBaseManager.coinsRecord;


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
