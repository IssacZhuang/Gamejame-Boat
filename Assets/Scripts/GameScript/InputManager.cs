using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
public class InputManager : GameComponent
{
    //GameManager gameManager;
    StageManager stageManager;

    // to store data for each stage
    private int indexCounter = 0;
    private List<Character> characters = new List<Character>();
    private List<Character> charactersCanPeek = new List<Character>();
    private Dictionary<Character, List<Verb>> charactersPrepareVerb = new Dictionary<Character, List<Verb>>();
    private Dictionary<Character, List<Verb>> charactersPeekVerb = new Dictionary<Character, List<Verb>>();
    private Dictionary<Character, List<Verb>> charactersInvokeVerb = new Dictionary<Character, List<Verb>>();


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
        //stageManager.StartNewStage();
    }

    public void AddNewCharacter()
    {
        stageManager.AddNewCharacter();

    }

    // --------------PrepareStage--------------
    public void GuiPrepareStartCallBack()
    {
        indexCounter = 0;
        // get all charactors
        characters = stageManager.Characters;
        // reset Dictionary
        charactersCanPeek = new List<Character>();
        charactersPrepareVerb = new Dictionary<Character, List<Verb>>();
        charactersPeekVerb = new Dictionary<Character, List<Verb>>();
        charactersInvokeVerb = new Dictionary<Character, List<Verb>>();
    }

    public Character GuiPrepareGetCharacterCallBack()
    {
        //return character or null
        if (characters.Count == indexCounter)
        {
            indexCounter += 1;
            return characters[indexCounter];
        }
        indexCounter += 1;
        return null;
    }

    public void GuiPrepareSelectCallBack(Character targetCharacter, List<Verb> verblist)
    {
        charactersPrepareVerb[targetCharacter] = verblist;
        charactersInvokeVerb[targetCharacter] = verblist;
    }

    public void GuiPrepareEndCallBack()
    {
        return;
    }


    // --------------PeekStage--------------
    public void GuiPeekStartCallBack()
    {
        indexCounter = 0;
        CheckPeek();
    }

    public Character GuiPeekCallBack()
    {
        //return character or null
        if (charactersCanPeek.Count == indexCounter)
        {
            indexCounter += 1;
            return charactersCanPeek[indexCounter];
        }
        indexCounter += 1;
        return null;
    }

    public void GuiPeekSelectCallBack(Character targetCharacter, List<Verb> verblist)
    {
        charactersPeekVerb[targetCharacter] = verblist;
        charactersInvokeVerb[targetCharacter] = verblist;
    }

    public void GuiPeekEndCallBack()
    {
        InvokeResult();
    }

    // --------------get information--------------
    public Dictionary<Character, List<Verb>> GuiGetPrepareDictCallBack()
    {
        return charactersPrepareVerb;
    }

    // Utility functions
    private bool CanPeek(Character character, List<Verb> verbList)
    {
        // check if has null
        if (verbList[0] is null || verbList[1] is null)
        {
            return true;
        }
        return false;
    }

    private void CheckPeek()
    {
        foreach (KeyValuePair<Character, List<Verb>> entry in charactersPrepareVerb)
        {
            if (CanPeek(entry.Key, entry.Value))
            {
                charactersCanPeek.Add(entry.Key);
            }
        }
    }

    private void InvokeResult()
    {
        // invoke(charactersInvokeVerb)
        return;
    }

}
