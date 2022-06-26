using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
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

    public void StartTest()
    {
        //inputManager.GuiPrepareStartCallBack();
        Debug.Log("start test");
        inputManager.GuiPrepareStartCallBack();
        Character character = inputManager.GuiPrepareGetCharacterCallBack();
        //Debug.Log(character == null);
        if (character != null)
        {
            Debug.Log("character found");
            List<VerbDef> verbInHand = character.VerbInhand;
            cardList = new List<CardScript>();
            int counter = 0;
            Debug.Log(verbInHand.Count);
            foreach (VerbDef verbDef in verbInHand)
            {
                if (fireballCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return;
                }
                if (splitFireballCard == null)
                {
                    UnityEngine.Debug.LogError("No splitFireballCard prefab set");
                    return;
                }

                if (meteoroliteCard == null)
                {
                    UnityEngine.Debug.LogError("No meteoroliteCard prefab set");
                    return;
                }

                if (defendCard == null)
                {
                    UnityEngine.Debug.LogError("No fireballCard prefab set");
                    return;
                }

                if (movementCard == null)
                {
                    UnityEngine.Debug.LogError("No movementCard prefab set");
                    return;
                }

                if (peekCard == null)
                {
                    UnityEngine.Debug.LogError("No peekCard prefab set");
                    return;
                }

                GameObject cardObj = null;
                if (verbDef.workerClass == typeof(Verb_ShootFireBall))
                {
                    cardObj = GameObject.Instantiate(fireballCard);
                }
                if (verbDef.workerClass == typeof(Verb_ShootSplitFireBall))
                {
                    cardObj = GameObject.Instantiate(splitFireballCard);
                }
                if (verbDef.workerClass == typeof(Verb_ShootMeteorite))
                {
                    cardObj = GameObject.Instantiate(meteoroliteCard);
                }
                if (verbDef.workerClass == typeof(Verb_Defend))
                {
                    cardObj = GameObject.Instantiate(defendCard);
                }
                if (verbDef.workerClass == typeof(Verb_Move))
                {
                    cardObj = GameObject.Instantiate(movementCard);
                }
                if (verbDef.workerClass == typeof(Verb_Peek))
                {
                    cardObj = GameObject.Instantiate(peekCard);
                }
                if (cardObj != null)
                {
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef,character);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }

            }
        }
        slot1.isFilled = true;
        slot1.slotIcon.sprite = fireballIcon;
    }

    public bool IfSlotsAllFilled()
    {
        return slot1.isFilled && slot2.isFilled;
    }

    public void FillSlot(Verb verb)
    {
        if (!IfSlotsAllFilled())
        {

        }
    }
    public void Slot1Clicked()
    {
        //Debug.Log("Slot1 clicked");
        if (slot1.isFilled)
        {
            slot1.slotIcon.sprite = null;
            slot1.isFilled = false;
        }
    }


    public void Slot2Clicked()
    {
        if (slot2.isFilled)
        {
            slot2.slotIcon.sprite = null;
            slot2.isFilled = false;
        }
    }


    public void GenerateCard()
    {

    }

    public void SwitchCharacter()
    {

    }

    public void SelectCard()
    {

    }

    public void Test()
    {
        Debug.Log("Card Clicked");
    }

}