using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
    public GameObject[] playerPrefab;
    public Transform[] spawnPoints;

    public InteractionManager interactionManager;
    public InputManager inputManager;

    private int playerLimit;


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
            if (!characters.Any(x => x.VerbTracker.HasQueuedVerb))
            {
                UnityEngine.Debug.Log("stopped");
                StopQueuedVerbs();
            }

            if (currentCharacter.VerbTracker.IsCurrentVerbFinished || (!currentCharacter.VerbTracker.HasQueuedVerb && !currentCharacter.VerbTracker.IsCurrentVerbOnGoing))
            {
                NextCharacter();
            }


            if (!currentCharacter.VerbTracker.IsCurrentVerbOnGoing)
            {
                currentCharacter.VerbTracker.NextVerb();
            }


        }
    }

    public void AddNewCharacter(int i)
    {
        //UnityEngine.Debug.Log("Add new character");
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
        //UnityEngine.Debug.Log("New character generated");

        GameObject player = GameObject.Instantiate(playerPrefab[i]);
        Character character = player.GetComponent<Character>();
        character.InitData();

        character.VerbInhand.Add(VerbDefOf.movementBasic);
        character.VerbInhand.Add(VerbDefOf.attackFireball);
        character.VerbInhand.Add(VerbDefOf.defendBasic);
        character.VerbInhand.Add(VerbDefOf.peek);

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
        playerLimit = playerPrefab.Length;

        for (int i = 0; i < playerLimit; i++)
        {
            AddNewCharacter(i % 2);
        }
        UnityEngine.Debug.Log(characters.Count);

        interactionManager.intStatus();
    }

    public void SortCharacter()
    {
        sortedCharacter.Clear();
        sortedCharacter.AddRange(characters);
        sortedCharacter.Sort(Compare);
    }

    public void StartQueuedVerbs()
    {
        SortCharacter();
        isVerbStarted = true;
    }

    public void StopQueuedVerbs()
    {
        isVerbStarted = false;
    }

    public void DebugPrintSoertedCharacterVerb()
    {
        foreach (var character in sortedCharacter)
        {
            UnityEngine.Debug.Log("verb: " + character.VerbTracker.PeekVerb().def.defName);
        }
    }

    public void SetCharacterVerbs(Dictionary<Character, List<Verb>> verbs)
    {
        foreach (var character in characters)
        {
            foreach (var verb in verbs[character])
            {
                character.VerbTracker.AddVerb(verb);
            }
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
