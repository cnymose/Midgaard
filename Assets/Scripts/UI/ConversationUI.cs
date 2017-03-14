using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Midgaard
{
    public class ConversationUI : MonoBehaviour
    { //This controls the "one of a kind" conversation UI.
        public Text text;
        public Text[] choices;
        public int choicePointer = 0;
        public int currentChoices;
        public Color highlightedColor;
        public Color normalColor;

        public InputHandler inputHandler;

        void Start()
        {
           
        }


        void Update()
        {
            for (int i = 0; i < choices.Length; i++) {
                if (i == choicePointer)
                {
                    choices[i].color = highlightedColor;
                }
                else {
                    choices[i].color = normalColor;
                }
            }
        }
        public void Cleanup() {
            choicePointer = 0;
            inputHandler.conversationChoice = false;
            for (int i = 0; i < choices.Length; i++) {
                choices[i].text = "";
                choices[i].gameObject.SetActive(false);
            }
        }

        public void SetChoices(string[] choiceStrings) {
            inputHandler.conversationChoice = true;
            for (int i = 0; i < choices.Length; i++)
            {
                if (choiceStrings[i] != null)
                {
                    choices[i].gameObject.SetActive(true);
                    choices[i].text = choiceStrings[i];
                }
            }
        }

        public void SetText(string inputText)
        {
            text.text = inputText;                      //Set the text of the conversation
        }
    }
}
