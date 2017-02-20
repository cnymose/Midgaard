using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationUI : MonoBehaviour { //This controls the "one of a kind" conversation UI.
    public Text text;


    void Start() {

    }

  
    void Update() {

    }

    public void SetText(string inputText) {
        text.text = inputText;                      //Set the text of the conversation
    }
}
