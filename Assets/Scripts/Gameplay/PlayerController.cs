using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int turbo;
    private Vector3 aceleration;
    public float velocidad;
    public float velocidad2;

    public SwitchControl switchControlReference;
    public MovementArrow buttonControlReference;

    void Update()
    {

        if (switchControlReference.controls.Equals(Control.acelerometer))
        {
            acelerometerControl();
        }
        if (switchControlReference.controls.Equals(Control.arrows))
        {
            ArrowsControl();
        }
    }
    public void acelerometerControl()
    {
        aceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        /*text1.text = "X: " + aceleration.x.ToString();
        text2.text = "Y: " + aceleration.y.ToString();
        text3.text = "Z: " + aceleration.z.ToString();*/

        if (Mathf.Abs(aceleration.x) > 0.05f && Mathf.Abs(aceleration.z) > 0.05f)
        {
            Vector3 movimiento = this.transform.right * velocidad2 * aceleration.z * Time.deltaTime;
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

    public void add1turbo() 
    {
        turbo++;
    }
    
    public void add1score() 
    {
        score++;
    }
}
