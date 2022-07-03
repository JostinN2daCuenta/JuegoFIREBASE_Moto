using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;


public class DataBaseManager : MonoBehaviour
{
    DatabaseReference reference;

    public bool existeUsuario;
    public float kilometosRecord;
    public float coinsRecord;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        existeUsuario = false;

        existeUsuarioFunction(GameManager.instance.getPlayerID());
    }

    public void existeUsuarioFunction(int id)
    {
        reference.Child("User").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot data = task.Result;
                if (data.Exists)
                {
                    foreach (var item in data.Children)
                    {
                        if (id.ToString() == item.Child("id").Value.ToString())
                        {
                            existeUsuario = true;
                            kilometosRecord = (float)Convert.ToDouble(item.Child("kilometros").Value);
                            coinsRecord = (float)Convert.ToDouble(item.Child("coins").Value);
                        }
                    }
                }
            }
        });
    }
    public void sendData(float kilometros, int coins) 
    {
        if (existeUsuario) 
        {
            if (kilometosRecord < kilometros) 
            {
                kilometosRecord = kilometros;
            }
            if (coinsRecord < coins) 
            {
                coinsRecord = coins;
            }
        }

        reference.Child("User").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                UserController user = new UserController(GameManager.instance.getPlayerID(), kilometosRecord, (int)coinsRecord);

                string json = JsonUtility.ToJson(user);

                reference.Child("User").Child(user.id.ToString()).SetRawJsonValueAsync(json).ContinueWith(
                    task2 =>
                    {
                        if (task2.IsCompleted)
                        {
                            Debug.Log("Se enviaron los datos del usuario");
                        }
                        else
                        {
                            Debug.Log("NO se pudo enviar los datos del usuario, nt :c");
                        }
                    }
                );
            }
        });

    }

}
