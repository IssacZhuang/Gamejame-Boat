using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
<<<<<<< Updated upstream
    int term;
    List<Character> characterList;

    public void StartNewStage()
    {
        term++;
        characterList = new List<Character>();
=======
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    public InteractionManager interactionManager;
    public InputManager inputManager;

    public List<Character> Characters => characters;

    private List<Character> characters = new List<Character>();
    private List<Character> sortedCharacter = new List<Character>();

    private int playersLimit = 2;

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
        for (int i = 0; i < playersLimit; i++)
        {
            AddNewCharacter();
        }

        interactionManager.StartTest();

>>>>>>> Stashed changes
    }

    public void AddNewCharacter()
    {
        characterList.Add(new Character());
    }

    public void StageTick()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        term = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
