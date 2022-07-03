using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Control { arrows, acelerometer, none }

public class SwitchControl : MonoBehaviour
{
    public PlayerController pController;
    public Sprite acelerometer;

    public Sprite arrows;
    public GameObject buttonsArrows;
    public Image myIMG;
    public Control controls;
    private void Start()
    {
        myIMG = GetComponent<Image>();
        controls = Control.arrows;
        myIMG.sprite = acelerometer;
    }
    public void Switch()
    {
        if (controls.Equals(Control.arrows))
        {
            myIMG.sprite = arrows;
            controls = Control.acelerometer;
            buttonsArrows.gameObject.SetActive(false);
        }

        else if (controls.Equals(Control.acelerometer))
        {
            myIMG.sprite = acelerometer;
            controls = Control.arrows;
            buttonsArrows.gameObject.SetActive(true);
        }

        else
        {

        }
    }
}
