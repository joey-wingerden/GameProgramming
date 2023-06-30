using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapping : MonoBehaviour
{
    //menus
    public Canvas Menus;
    public Canvas GameOverLay;
    
    
    public GameObject main;
    public GameObject Settings;
    public GameObject PauzeMenus;
    public GameObject gameOverMenu;
    public Game game;

    

    private string NameOfMenu;
    public void ResetGame()
    {
        
        if (game.gamePauze)
        {
            Debug.Log("console");
            Menus.enabled = false;
            GameOverLay.enabled = true;

            gameOverMenu.SetActive(false);
            PauzeMenus.SetActive(false);

            //game.GameRunning = true;
            game.ResetGame();
            //game.gamePauze = false;
            //
            
            
            //game.TurnGameonn();
            NameOfMenu = "";
        }
    }

    public void Resume()
    {
        game.TurnGameonn();
        PauzeMenus.SetActive(false);
        NameOfMenu = "";
    }
    public void BackTomainMenu()
    {
        Menus.enabled = true;
        GameOverLay.enabled = false;

        main.SetActive(true);
        Settings.SetActive(false);
        NameOfMenu = "mainMenu";
    }
     public void SettingScreen()
    {
        Menus.enabled = true;
        GameOverLay.enabled = false;

        main.SetActive(false);
        Settings.SetActive(true);
        NameOfMenu = "mainMenu";
    }

    public void GameOverScreen()
    {
        gameOverMenu.SetActive(true);
        PauzeMenus.SetActive(false);
        NameOfMenu = "gameOverMenu";
    }
    public void PauzeMenuScreen()
    {
        gameOverMenu.SetActive(false);
        PauzeMenus.SetActive(true);
        NameOfMenu = "PauzeMenus";
    }

    public void GameExit()
    {
        Application.Quit();
    }
}

