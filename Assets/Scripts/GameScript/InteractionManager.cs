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
    public GameObject playerPrefab;
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
                //Debug.Log("test");
                //GameObject cardObj = GameObject.Instantiate(fireballCard);
                //CardScript card = cardObj.GetComponent<CardScript>();
                //card.InitializeCard(verbDef);
                //card.transform.parent = CardUIParentTransform.transform;
                //card.transform.position = cardPosition[counter++].position;

                //CardScript card = cardObj.GetComponent<CardScript>();
                //card.InitializeCard(verbDef);
                ////card.transform.position = cardPosition[counter++].position;
                //cardList.Add(card);

                if (verbDef.workerClass == typeof(Verb_ShootFireBall))
                {
                    GameObject cardObj = GameObject.Instantiate(fireballCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }
                if (verbDef.workerClass == typeof(Verb_ShootSplitFireBall))
                {
                    GameObject cardObj = GameObject.Instantiate(splitFireballCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }
                if (verbDef.workerClass == typeof(Verb_ShootMeteorite))
                {
                    GameObject cardObj = GameObject.Instantiate(meteoroliteCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }
                if (verbDef.workerClass == typeof(Verb_Defend))
                {
                    GameObject cardObj = GameObject.Instantiate(defendCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }
                if (verbDef.workerClass == typeof(Verb_Move))
                {
                    GameObject cardObj = GameObject.Instantiate(movementCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }
                if (verbDef.workerClass == typeof(Verb_Peek))
                {
                    GameObject cardObj = GameObject.Instantiate(peekCard);
                    CardScript card = cardObj.GetComponent<CardScript>();
                    card.InitializeCard(verbDef);
                    card.transform.parent = CardUIParentTransform.transform;
                    card.transform.position = cardPosition[counter++].position;
                    cardList.Add(card);
                }


                //GameObject cardObj = GameObject.Instantiate(cardPrefab);
                //CardScript card = cardObj.GetComponent<CardScript>();
                //card.InitializeCard(verbDef);
                //card.transform.position = cardPosition[counter++].position;
                //cardList.Add(card);

                //GameObject cardObj = GameObject.Instantiate(playerPrefab);
                //cardObj.transform.position = cardPosition[0].position;
            }
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

}