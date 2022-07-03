using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class DataBaseManager : MonoBehaviour
{
    DatabaseReference reference;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        test();
    }


    public void test() 
    {
        UserController user = new UserController();
        UserController.id = Random.Range(0, 9999);
        user.nickName = "pepe";
        user.score = 0;
        string json = JsonUtility.ToJson(user);
        reference.Child("User").Child(UserController.id.ToString()).SetRawJsonValueAsync(json).ContinueWith(
            task =>
            {
                if (task.IsCompleted)
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
}
