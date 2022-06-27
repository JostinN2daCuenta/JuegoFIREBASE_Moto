using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneEvent 
{
    public static System.Action eventsBeforeChangeScene;
    public static System.Action eventsAfterChangeScene;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public string nameScene;
    public bool inGame;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        inGame = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            loadNextScene();
        }
    }

    public void loadNextScene() 
    {
        StartCoroutine(asycLoadScene());
    }
    IEnumerator asycLoadScene() 
    {
        LoadSceneEvent.eventsBeforeChangeScene?.Invoke();
        yield return new WaitForSeconds(1);


        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!op.isDone)
        {
            yield return null;
        }
    }

}
