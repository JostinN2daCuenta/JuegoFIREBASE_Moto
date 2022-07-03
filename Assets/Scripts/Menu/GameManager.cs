using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneEvent 
{
    public static System.Action eventsBeforeChangeScene;
    public static System.Action eventsAfterChangeScene;
}

public class GameOverEvent
{
    public static System.Action eventGameOver;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public string nameScene;
    public bool inGame;
    public bool gameOverVariable;




    /*PLAYER ID  test*/
    public int PlayerID;

    private void Awake()
    {
        gameOverVariable = false;
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
        /*PLAYER ID  test*/
        if (PlayerPrefs.GetInt("ID") == 0) 
        {
            setPlayerID();
        }
        PlayerID = getPlayerID();



        inGame = false;
    }
    void Update()
    {

    }

    public void gameOver() 
    {
        gameOverVariable = true;
        GameOverEvent.eventGameOver?.Invoke();
        GameOverEvent.eventGameOver = null;
    }
    public void loadNextScene() 
    {
        StartCoroutine(asycLoadScene(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void restartScene()
    {
        gameOverVariable = false;
        StartCoroutine(asycLoadScene(SceneManager.GetActiveScene().buildIndex));
    }


    IEnumerator asycLoadScene(int i) 
    {
        yield return new WaitForSeconds(1);


        AsyncOperation op = SceneManager.LoadSceneAsync(i);
        while (!op.isDone)
        {
            yield return null;
        }
    }


    /*PLAYER ID  test*/
    public void setPlayerID() 
    {
        PlayerPrefs.SetInt("ID", Random.Range(0, 100));
    }

    public int getPlayerID()
    {
        return PlayerPrefs.GetInt("ID");
    }

}
