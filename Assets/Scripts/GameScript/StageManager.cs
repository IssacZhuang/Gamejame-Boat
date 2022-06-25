using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    private List<Character> characters = new List<Character>();

    public void StartNewStage()
    {
        
    }

    public void AddNewCharacter()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("No playerPrefab set");
            return;
        }

        if (characters.Count >= spawnPoints.Length)
        {
            Debug.LogError("No spawn point for new player");
            return;
        }

        GameObject player = GameObject.Instantiate(playerPrefab);
        Character character = player.GetComponent<Character>();
        characters.Add(character);
        character.transform.position = spawnPoints[characters.Count - 1].position;
    }

    public void StageTick()
    {

    }
}
