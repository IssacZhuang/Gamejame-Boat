using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GameComponent
{
    //GameManager gameManager;
    StageManager stageManager;

    public void StartGame()
    {
        //gameManager.StartGame();
    }

    public void ExitGame()
    {
        System.Environment.Exit(0);
    }

    public void StartNewStage()
    {
        stageManager.StartNewStage();
    }

    public void AddNewCharacter()
    {
        stageManager.AddNewCharacter();

    }
}
