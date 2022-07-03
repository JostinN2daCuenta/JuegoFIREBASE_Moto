using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMoto : MonoBehaviour
{
    public Material[] Color1,Color2;
    public GameObject[] PartesColorPrimario, PartesColorSecundario;

    public int personaje;
    // Start is called before the first frame update

    private void Awake()
    {
        personaje = PlayerPrefs.GetInt("color");
        Debug.Log(personaje);
        
    }
    void Start()
    {
        if (personaje == 1)
        {
            Debug.Log("Morado");
            foreach (var partes in PartesColorPrimario)
                partes.gameObject.GetComponent<MeshRenderer>().material = Color1[0];
            foreach (var partes in PartesColorSecundario)
                partes.gameObject.GetComponent<MeshRenderer>().material = Color1[1];
        }

        else if (personaje == 2)
        {
            Debug.Log("Verde");
            foreach (var partes in PartesColorPrimario)
                partes.gameObject.GetComponent<MeshRenderer>().material = Color2[0];
            foreach (var partes in PartesColorSecundario)
                partes.gameObject.GetComponent<MeshRenderer>().material = Color2[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
