using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    private List<Character> characters = new List<Character>();
    private List<Character> sortedCharacter = new List<Character>();
    private Character currentCharacter => (sortedCharacter.Count == 0 || currentIndex > sortedCharacter.Count - 1) ? null : sortedCharacter[currentIndex];

    private int currentIndex = 0;

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

    public void NextPlayer()
    {
        currentIndex++;
        if (currentIndex >= characters.Count) currentIndex = 0;
    }

    public void NextTerm()
    {
        SortCharacter();
    }

    public void StartNewStage()
    {

    }

    private void SortCharacter()
    {
        sortedCharacter.Sort(Compare);
    }

    private int Compare(Character a, Character b)
    {
        Verb verbA = a.VerbTracker.PeekVerb();
        Verb verbB = b.VerbTracker.PeekVerb();

        if (verbA.def.priority > verbB.def.priority)
        {
            return 1;
        }

        if (verbA.def.priority < verbB.def.priority)
        {
            return -1;
        }

        return 0;
    }
}
