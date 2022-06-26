using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    public Button slotButton;
    public GameObject chosenCard;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = slotButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    { 

    }

    }
