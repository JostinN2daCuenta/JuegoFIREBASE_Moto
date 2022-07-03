using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] TextMeshProUGUI x;
    [SerializeField] TextMeshProUGUI y;
    [SerializeField] TextMeshProUGUI z;*/

    public int score;
    public int turbo;
    public int coins;
    private Vector3 aceleration;
    public float velocidad;
    public float velocidad2;

    public float tiempoEntreTurbos = 5f;


    public MovementArrow buttonControlReference;
    public UIController UIReference;
    SwitchControl switchControlReference;

    private void Start()
    {
        switchControlReference = UIReference.switchControl_;
        StartCoroutine("agregarTurbo");
    }
    IEnumerator agregarTurbo()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreTurbos);
            add1turbo();
        }
    }
    void Update()
    {
        if (this.transform.position.x < 36)
            this.transform.position += new Vector3(0.002f,0,0);
        if(this.transform.position.x > 47)
            this.transform.position += new Vector3(-0.002f, 0, 0);
        if (!GameManager.instance.gameOverVariable && this.transform.position.x > 36 && this.transform.position.x<47) 
        {
            Vector3 movimiento = this.transform.right * velocidad * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position -= movimiento;
            }


            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += movimiento;
            }

#if UNITY_ANDROID
            if (switchControlReference.controls.Equals(Control.acelerometer))
            {
                acelerometerControl();
            }
            if (switchControlReference.controls.Equals(Control.arrows))
            {
                ArrowsControl();
            }
#endif
        }


    }
    public void acelerometerControl()
    {
        aceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        /*x.text = "X: " + aceleration.x.ToString();
        y.text = "Y: " + aceleration.y.ToString();
        z.text = "Z: " + aceleration.z.ToString();*/

        if (Mathf.Abs(aceleration.x) > 0.05f)
        {
            Vector3 movimiento = this.transform.right * velocidad2 * aceleration.x * Time.deltaTime;
            this.transform.position += movimiento;
        }
    }

    public void ArrowsControl()
    {
        if (buttonControlReference != null)
        {
            int directionLnR = buttonControlReference.direction;

            Vector3 movimiento = this.transform.right * velocidad * directionLnR * Time.deltaTime;
            this.transform.position += movimiento;
        }
    }

    public void add1Coin() 
    {
        coins++;
        UIReference.mofifyCoinText(coins);
    }
    public void add1turbo() 
    {
        turbo++;
        UIReference.llenarTurbo();
    }
    
    public void add1score() 
    {
        score++;
    }
}
