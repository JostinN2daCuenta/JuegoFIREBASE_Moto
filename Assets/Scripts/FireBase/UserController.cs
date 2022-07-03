using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController
{
    public int id;
    public float kilometros;
    public int coins;

    public UserController(int id, float kilometrosRecord, int coinsRecord)
    {
        this.id = id;
        this.kilometros = kilometrosRecord;
        this.coins = coinsRecord;
    }
}
