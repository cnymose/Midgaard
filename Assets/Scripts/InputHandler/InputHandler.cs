using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class InputHandler : MonoBehaviour
    {
        public bool conversationChoice = false;
        public ConversationUI conversationUI;

        void Start() {

        }

        void Update() {
            if (conversationChoice) { //If we are in conversation choice mode (This will be rewritten to state later)
                if (Input.GetKeyDown(KeyCode.W)) {
                    if (conversationUI.choicePointer > 0)
                    conversationUI.choicePointer--;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (conversationUI.choicePointer < conversationUI.currentChoices)
                    conversationUI.choicePointer++;
                }
            }
        }

        public static IEnumerator WaitForButtonDown(string button)
        { //This Coroutine waits for the input of a button with the argument being a string of the input button name.

            while (!Input.GetButtonDown(button))
            {
                yield return null;
            }
            yield return null;
        }


    }
}
