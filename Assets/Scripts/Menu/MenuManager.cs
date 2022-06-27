using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu1;
    [SerializeField] GameObject MainMenu2;

    public GameObject CurrentMainMenu;
    public bool inGame;

    private void Awake()
    {
 
    }
    void Start()
    {
        alreadyInGame();
        MenuManagerStart();
    }
    public void onClickStartGame() 
    {
        GameManager.instance.loadNextScene();
    }

    public void alreadyInGame() 
    {
        if (SceneManager.GetActiveScene().name == "Game")//cambiar esto con la variable biuld index, despues obviamente los gameplays no van a ser todos en una escena llamada game
        {
            inGame = true;
        }
    }

    public void MenuManagerStart() 
    {
        MainMenu1.gameObject.SetActive(false);
        MainMenu2.gameObject.SetActive(false);

        if (inGame)
        {
            CurrentMainMenu = MainMenu2;
        }
        else
        {
            CurrentMainMenu = MainMenu1;
            CurrentMainMenu.gameObject.SetActive(true);
        }
    }

}
