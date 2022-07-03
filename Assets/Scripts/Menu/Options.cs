using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    public MenuManager menuManager;


    public Slider volume;
    public Slider brillo;
    public Image brilloImage;
    public TextMeshProUGUI colorText;
    void Start()
    {
        colorText.text = PlayerPrefs.GetInt("color") == 1?  colorText.text = "Morado" : colorText.text = "Verde";
        menuManager = GetComponent<MenuManager>();
        volume.value = PlayerPrefs.GetFloat("Volume");

        updateBrilloImagen(PlayerPrefs.GetFloat("Brillo"));
        brillo.value = PlayerPrefs.GetFloat("Brillo");
    }

    public void closeMenu() 
    {
        menuManager.CurrentMainMenu.gameObject.SetActive(true);
    }
    public void setVolume() 
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
    }

    public void setBrightness()
    {
        updateBrilloImagen(brillo.value);
    }

    public void updateBrilloImagen(float a) //1 es brillo max
    {
        PlayerPrefs.SetFloat("Brillo", a);
        float alpha = 1 - a;
        brilloImage.color = new Color(brilloImage.color.r, brilloImage.color.g, brilloImage.color.b, Mathf.Clamp(alpha, 0.0f, 0.7f));
    }

    public void CambiarColor()
    {
        if (PlayerPrefs.GetInt("color") == 1)
        {
            colorText.text = "Verde";
            PlayerPrefs.SetInt("color", 2);
            Debug.Log("Cambio de color verde");
        }    
        else
        {
            colorText.text = "Morado";
            PlayerPrefs.SetInt("color", 1);
            Debug.Log("Cambio de color morado");
        }
            
    }

    public void GetCurrentColor()
    {
        
    }
}
