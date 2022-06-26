using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject readyButton;
    public drawIndicator indicator;
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
    private bool isPrepareStage;
    private bool hasNextPrepare;
    private bool isPrepareDone;

    private bool isPeekStage;
    private bool hasNextPeek;
    private bool isPeekDone;



    public void Start()
    {
        //inputManager.GuiPrepareStartCallBack();
        //Debug.Log("start test");
        intStatus();
        //slot1.isFilled = true;
        //slot1.slotIcon.sprite = fireballIcon;
    }

    public void intStatus()
    {
        //isPrepare = true;
        inputManager.GuiPrepareStartCallBack();
        isPrepareStage = true;
        isPrepareDone = true;
        isPeekStage = false;
        isPeekDone = true;
    }

    public void Update()
    {
        bool isGameStart = inputManager.GuiCheckGameStartCallBack();
        // ??????? (isPrepareStage=true)
        // ???isPrepareDone????true
        // ?????????isPrepareDone???true
        if (isPrepareStage && isPrepareDone && isGameStart)
        {
            // ??????, ????????gui?
            hasNextPrepare = PreparationSwitchCharacter();
            // ?????, ??isPrepareDone?false??????
            if (hasNextPrepare)
            {
                isPrepareDone = false;
                // ?????ready???????????, ??isPrepareDone?true
                readyButton.GetComponent<Button>().onClick.RemoveAllListeners();
                readyButton.GetComponent<Button>().onClick.AddListener(PreparationFinishedCallBack);
            }
        }

        // ?????????, ???peek??
        if (isPrepareStage && !hasNextPrepare)
        {
            inputManager.GuiPrepareEndCallBack();
            inputManager.GuiPeekStartCallBack();
            isPrepareStage = false;
            isPeekStage = true;
        }

        if (isPeekStage && isPeekDone)
        {
            hasNextPeek = PeekSwitchCharacter();
            // ?????, ??isPrepareDone?false??????
            if (hasNextPeek)
            {
                isPeekDone = false;
                // ?????ready???????????, ??isPrepareDone?true
                readyButton.GetComponent<Button>().onClick.RemoveAllListeners();
                readyButton.GetComponent<Button>().onClick.AddListener(PeekFinishedCallBack);
            }
        }

        // ??peek????????, ???invoke??
        if (isPeekStage && !hasNextPeek)
        {
            isPeekStage = false;
            // peek stage end
            inputManager.GuiPeekEndCallBack();
        }

        // ???????, ????????
        if(!isPrepareStage && !isPrepareStage)
        {
            intStatus();
        }

    }

    private void InitSelectionState()
    {
        if (cardList != null)
        {
            foreach (var card in cardList)
            {
                card.Destroy();
            }
            cardList = new List<CardScript>();
        }
        if (slot1.isFilled) slot1.RemoveIcon();
        if (slot2.isFilled) slot2.RemoveIcon();
    }


    private bool PreparationSwitchCharacter()
    {
        // ????????slot
        InitSelectionState();
        Character character = inputManager.GuiPrepareGetCharacterCallBack();
        // Debug.Log(character == null);
        // ?????
        if (character != null)
        {
            //Debug.Log("character found");
            currentCharacter = character;
            List<VerbDef> verbInHand = character.VerbInhand;
            cardList = new List<CardScript>();
            verbList = new List<Verb>(new Verb[2]);
            int counter = 0;
            //Debug.Log(verbInHand.Count);
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
        return false;
    }

    private bool PeekSwitchCharacter()
    {
        InitSelectionState();
        Character character = inputManager.GuiPeekGetCharacterCallBack();
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
            // ???icon
            FillSlot(verbList[0]);
            FillSlot(verbList[1]);


            return true;
        }
        return false;
    }

    public bool IfSlotsAllFilled()
    {
        return slot1.isFilled && slot2.isFilled;
    }

    public void FillSlotIcon(Verb verb, SlotScript slot)
    {
        if (verb.def == VerbDefOf.attackFireball)
        {
            slot.SetIcon(fireballIcon);
        }
        if (verb.def == VerbDefOf.attackSplitFireball)
        {
            slot.SetIcon(splitFireballIcon);
        }
        if (verb.def == VerbDefOf.attackMeteorolite)
        {
            slot.SetIcon(meteoroliteIcon);
        }
        if (verb.def == VerbDefOf.defendBasic)
        {
            slot.SetIcon(defendIcon);
        }
        if (verb.def == VerbDefOf.movementBasic)
        {
            slot.SetIcon(movementIcon);
        }
        if (verb.def == VerbDefOf.peek)
        {
            slot.SetIcon(peekIcon);
        }
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
                    FillSlotIcon(verb, slot1);
                }
                else if (!slot2.isFilled)
                {
                    verbList[1] = verb;
                    FillSlotIcon(verb, slot2);
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

    public void PreparationFinishedCallBack()
    {
        // ?????????result????
        // ?????, ?????
        if (IfSlotsAllFilled())
        {
            inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
            isPrepareDone = true;
            return;
        }
        // ????????, ?????peek
        foreach (Verb verb in verbList)
        {
            if (verb.def == VerbDefOf.peek)
            {
                inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
                isPrepareDone = true;
                return;
            }
        }
        // ?????, ???
        Debug.Log("You are not finished");
        isPrepareDone = false;
        return;
    }

    public void PeekFinishedCallBack()
    {
        // ?????, ?????
        if (IfSlotsAllFilled())
        {
            inputManager.GuiPeekSelectCallBack(currentCharacter, verbList);
            isPeekDone = true;
        }
        // ?????, ???
        Debug.Log("You are not finished");
        isPeekDone = false;
    }


    //public void CharacterPreparationFinished()
    //{
    //    if (isPrepare)
    //    {
    //        if (IfSlotsAllFilled())
    //        {
    //            inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
    //        }
    //        else
    //        {
    //            foreach(Verb verb in verbList)
    //            {
    //                if (verb.def == VerbDefOf.peek)
    //                {
    //                    inputManager.GuiPrepareSelectCallBack(currentCharacter, verbList);
    //                    break;
    //                }
    //            }
    //            Debug.Log("You are not finished");
    //            return;

    //        }
    //        if (!PreparationSwitchCharacter())
    //        {
    //            currentCharacter = null;
    //            cardList = null;
    //            verbList = null;
    //            inputManager.GuiPrepareEndCallBack();
    //            isPrepare = false;
    //            inputManager.GuiPeekStartCallBack();
    //            inputManager.GuiPeekCallBack();
    //        }
    //    }
    //    else
    //    {
    //        if (IfSlotsAllFilled())
    //        {
    //            inputManager.GuiPeekSelectCallBack(currentCharacter, verbList);
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //    if (!PeekSwitchCharacter())
    //    {
    //        currentCharacter = null;
    //        cardList = null;
    //        verbList = null;
    //        inputManager.GuiPeekEndCallBack();
    //    }
    //}

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