using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController reference;
    public int direction;
    public int id;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (id == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        reference.buttonControlReference = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = 0;
        reference.buttonControlReference = null;
    }
}