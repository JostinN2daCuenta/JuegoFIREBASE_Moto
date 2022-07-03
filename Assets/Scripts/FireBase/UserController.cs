using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController
{
    public static int id;
    public string nickName;
    public float score;

    public UserController()
    {
        if (id == 0) 
        {
            id = Random.Range(0, 1000);
        }
    }
}
