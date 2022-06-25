using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    public List<Character> Characters => characters;

    private List<Character> characters = new List<Character>();
    private List<Character> sortedCharacter = new List<Character>();

    private bool isVerbStarted = false;

    private Stopwatch timer = new Stopwatch();
    private Character currentCharacter => (sortedCharacter.Count == 0 || currentIndex > sortedCharacter.Count - 1) ? null : sortedCharacter[currentIndex];

    private int currentIndex = 0;

    public override void GameFixedUpdate()
    {
        base.GameFixedUpdate();
        if (isVerbStarted)
        {
            if (currentCharacter == null || currentCharacter.VerbTracker.PeekVerb() == null)
            {
                StopQueuedVerbs();
            }

            if (!currentCharacter.VerbTracker.IsCurrentVerbOnGoing)
            {
                currentCharacter.VerbTracker.NextVerb();
            }
        }
    }

    public void AddNewCharacter()
    {
        if (playerPrefab == null)
        {
            UnityEngine.Debug.LogError("No playerPrefab set");
            return;
        }

        if (characters.Count >= spawnPoints.Length)
        {
            UnityEngine.Debug.LogError("No spawn point for new player");
            return;
        }

        GameObject player = GameObject.Instantiate(playerPrefab);
        Character character = player.GetComponent<Character>();
        character.InitData();
        characters.Add(character);
        character.transform.position = spawnPoints[characters.Count - 1].position;
    }

    public void NextCharacter()
    {
        currentIndex++;
        if (currentIndex >= sortedCharacter.Count)
        {
            currentIndex = 0;
            NextTerm();
        }
    }

    public void NextTerm()
    {
        SortCharacter();
    }

    public void StartNewStage()
    {

    }

    public void SortCharacter()
    {
        sortedCharacter.Clear();
        sortedCharacter.AddRange(characters);
        sortedCharacter.Sort(Compare);
    }

    public void StartQueuedVerbs()
    {
        isVerbStarted = true;
    }

    public void StopQueuedVerbs()
    {
        isVerbStarted = false;
    }

    public void DebugPrintSoertedCharacterVerb()
    {
        foreach(var character in sortedCharacter)
        {
            UnityEngine.Debug.Log("verb: " + character.VerbTracker.PeekVerb().def.defName);
        }
    }

    private int Compare(Character a, Character b)
    {
        Verb verbA = a.VerbTracker.PeekVerb();
        Verb verbB = b.VerbTracker.PeekVerb();

        if(verbA == null && verbB == null)
        {
            return 0;
        }

        if (verbB == null || verbA.def.priority > verbB.def.priority)
        {
            return -1;
        }

        if (verbA == null || verbA.def.priority < verbB.def.priority)
        {
            return 1;
        }

        return 0;
    }
}
