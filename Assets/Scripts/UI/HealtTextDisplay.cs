using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealtTextDisplay : MonoBehaviour
{

    public GameObject player;
    public TMP_Text textDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //textDisplay.text = "Health: " + player.GetComponent<Character>().Health.ToString();
    }
}
