using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
public class StageManager : GameComponent
{
    int term;
    List<Character> characterList;

    public void StartNewStage()
    {
        term++;
        characterList = new List<Character>();
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
