using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scaffold;
public class InteractionManager : GameComponent
{
    public Transform[] cardPosition;
    public InputManager inputManager;
    public GameObject fireballCard;
    public GameObject splitFireballCard;
    public GameObject meteoroliteCard;
    public GameObject defendCard;
    public GameObject movementCard;
    public GameObject peekCard;
    public Sprite fireballIcon;
    public Sprite splitFireballIcon;
    public Sprite meteoroliteIcon;
    public Sprite defendIcon;
    public Sprite movementIcon;
    public Sprite peekIcon;
    public SlotScript slot1;
    public SlotScript slot2;
    public Transform CardUIParentTransform;
    private List<CardScript> cardList;
    private List<Verb> verbList;
    private Character currentCharacter;
    private bool isPrepare;

    public void StartTest()
    {
        //inputManager.GuiPrepareStartCallBack();
        //Debug.Log("start test");
        isPrepare = false;
        inputManager.GuiPrepareStartCallBack();
        PreparationSwitchCharacter();

        slot1.isFilled = true;
        slot1.slotIcon.sprite = fireballIcon;
    }


    private bool PreparationSwitchCharacter()
    {
        if (cardList != null)
        {
            while (cardList.Count > 0)
            {
                cardList[0].Destroy();
            }
        }

        if (slot1.isFilled)
        {
            slot1.RemoveIcon();
        }
        if (slot2.isFilled)
        {
            slot2.RemoveIcon();
        }
        Character character = inputManager.GuiPrepareGetCharacterCallBack();
        //Debug.Log(character == null);
        if (character != null)
        {
            Debug.Log("character found");
            currentCharacter = character;
            List<VerbDef> verbInHand = character.VerbInhand;
            cardList = new List<CardScript>();
            verbList = new List<Verb>(new Verb[2]);
            int counter = 0;
            Debug.Log(verbInHand.Count);
            foreach (VerbDef verbDef in verbInHand)
            {
                if (fireballCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return false;
                }
                if (splitFireballCard == null)
                {
                    UnityEngine.Debug.LogError("No splitFireballCard prefab set");
                    return false;
                }

                if (meteoroliteCard == null)
                {
                    UnityEngine.Debug.LogError("No meteoroliteCard prefab set");
                    return false;
                }

                if (defendCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return false;
                }

                if (movementCard == null)
                {
                    UnityEngine.Debug.LogError("No movementCard prefab set");
                    return false;
                }

                if (peekCard == null)
                {
                    UnityEngine.Debug.LogError("No peekCard prefab set");
                    return false;
                }

                GameObject cardObj = null;
                if (verbDef == VerbDefOf.attackFireball)
                {
                    cardObj = GameObject.Instantiate(fireballCard);
                }
                if (verbDef == VerbDefOf.attackSplitFireball)
                {
                    cardObj = GameObject.Instantiate(splitFireballCard);
                }
                if (verbDef == VerbDefOf.attackMeteorolite)
                {
                    cardObj = GameObject.Instantiate(meteoroliteCard);
                }
                if (verbDef == VerbDefOf.defendBasic)
                {
                    cardObj = GameObject.Instantiate(defendCard);
                }
                if (verbDef == VerbDefOf.movementBasic)
                {
                    cardObj = GameObject.Instantiate(movementCard);
                }
                if (verbDef == VerbDefOf.peek)
                {
                    cardObj = GameObject.Instantiate(peekCard);
                }
                if (cardObj != null)
                {
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef, character);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }

            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool PeekSwitchCharacter()
    {
        if (cardList != null)
        {
            while (cardList.Count > 0)
            {
                cardList[0].Destroy();
            }
        }
        if (slot1.isFilled)
        {
            slot1.RemoveIcon();
        }
        if (slot2.isFilled)
        {
            slot2.RemoveIcon();
        }
        Character character = inputManager.GuiPeekCallBack();
        //Debug.Log(character == null);
        if (character != null)
        {
            Debug.Log("character found");
            currentCharacter = character;
            List<VerbDef> verbInHand = character.VerbInhand;
            cardList = new List<CardScript>();
            verbList = inputManager.GuiGetPrepareDictCallBack(currentCharacter);
            int counter = 0;
            Debug.Log(verbInHand.Count);
            foreach (VerbDef verbDef in verbInHand)
            {
                if (fireballCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return false;
                }
                if (splitFireballCard == null)
                {
                    UnityEngine.Debug.LogError("No splitFireballCard prefab set");
                    return false;
                }

                if (meteoroliteCard == null)
                {
                    UnityEngine.Debug.LogError("No meteoroliteCard prefab set");
                    return false;
                }

                if (defendCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return false;
                }

                if (movementCard == null)
                {
                    UnityEngine.Debug.LogError("No movementCard prefab set");
                    return false;
                }

                if (peekCard == null)
                {
                    UnityEngine.Debug.LogError("No peekCard prefab set");
                    return false;
                }

                GameObject cardObj = null;
                if (verbDef == VerbDefOf.attackFireball)
                {
                    cardObj = GameObject.Instantiate(fireballCard);
                }if (verbDef == VerbDefOf.attackSplitFireball)
                {
                    cardObj = GameObject.Instantiate(splitFireballCard);
                }
                if (verbDef == VerbDefOf.attackMeteorolite)
                {
                    cardObj = GameObject.Instantiate(meteoroliteCard);
                }
                if (verbDef == VerbDefOf.defendBasic)
                {
                    cardObj = GameObject.Instantiate(defendCard);
                }
                if (verbDef == VerbDefOf.movementBasic)
                {
                    cardObj = GameObject.Instantiate(movementCard);
                }
                if (verbDef == VerbDefOf.peek)
                {
                    cardObj = GameObject.Instantiate(peekCard);
                }
                if (cardObj != null)
                {
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef, character);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }

            }

            //slot icon display

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IfSlotsAllFilled()
    {
        return slot1.isFilled && slot2.isFilled;
    }

    public void FillSlot(Verb verb)
    {
        if (verb != null && verb.def != null)
        {
            if (!IfSlotsAllFilled())
            {
                if (!slot1.isFilled)
                {
                    verbList[0] = verb;
                    Debug.Log(verb.def);
                    if (verb.def == VerbDefOf.attackFireball)
                    {
                        slot1.SetIcon(fireballIcon);
                    }
                    if (verb.def == VerbDefOf.attackSplitFireball)
                    {
                        slot1.SetIcon(splitFireballIcon);
                    }
                    if (verb.def == VerbDefOf.attackMeteorolite)
                    {
                        slot1.SetIcon(meteoroliteIcon);
                    }
                    if (verb.def == VerbDefOf.defendBasic)
                    {
                        slot1.SetIcon(defendIcon);
                    }
                    if (verb.def == VerbDefOf.movementBasic)
                    {
                        slot1.SetIcon(movementIcon);
                    }
                    if (verb.def == VerbDefOf.peek)
                    {
                        slot1.SetIcon(peekIcon);
                    }
                }
                else if (!slot2.isFilled)
                {
                    verbList[1] = verb;
                    if (verb.def == VerbDefOf.attackFireball)
                    {
                        slot2.SetIcon(fireballIcon);
                    }
                    if (verb.def == VerbDefOf.attackSplitFireball)
                    {
                        slot2.SetIcon(splitFireballIcon);
                    }
                    if (verb.def == VerbDefOf.attackMeteorolite)
                    {
                        slot2.SetIcon(meteoroliteIcon);
                    }
                    if (verb.def == VerbDefOf.defendBasic)
                    {
                        slot2.SetIcon(defendIcon);
                    }
                    if (verb.def == VerbDefOf.movementBasic)
                    {
                        slot2.SetIcon(movementIcon);
                    }
                    if (verb.def == VerbDefOf.peek)
                    {
                        slot2.SetIcon(peekIcon);
                    }
                }
            }
        }
        
    }
    //bug !!!!
    public void Slot1Clicked()
    {
        //Debug.Log("Slot1 clicked");
        if (slot1.isFilled && !isPrepare && !slot1.isPeek)
        {
            slot1.RemoveIcon();
            verbList[0] = null;
        }
    }


    public void Slot2Clicked()
    {
        if (slot2.isFilled && !isPrepare && !slot2.isPeek)
        {
            slot2.RemoveIcon();
            verbList[1] = null;
        }
    }

    public void CharacterPreparationFinished()
    {
        if (isPrepare)
        {
            if (IfSlotsAllFilled())
            {
                inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
            }
            else
            {
                foreach(Verb verb in verbList)
                {
                    if (verb.def == VerbDefOf.peek)
                    {
                        inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
                        break;
                    }
                }
                Debug.Log("You are not finished");
                return;

            }
            if (!PreparationSwitchCharacter())
            {
                currentCharacter = null;
                cardList = null;
                verbList = null;
                inputManager.GuiPrepareEndCallBack();
                isPrepare = false;
                inputManager.GuiPeekStartCallBack();
                inputManager.GuiPeekCallBack();
            }
        }
        else
        {
            if (IfSlotsAllFilled())
            {
                inputManager.GuiPeekSelectCallBack(currentCharacter, verbList);
            }
            else
            {
                return;
            }
        }
        if (!PeekSwitchCharacter())
        {
            currentCharacter = null;
            cardList = null;
            verbList = null;
            inputManager.GuiPeekEndCallBack();
        }
    }

    //public void CharacterPeekFinished()
    //{

    //}

    //public void GenerateCard()
    //{

    //}


    public void SelectCard()
    {

    }

    public void Test()
    {
        Debug.Log("Card Clicked");
    }

}