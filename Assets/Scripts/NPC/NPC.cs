using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Midgaard
{
    public class NPC : Interact
    {
        [System.Serializable]
        public struct ConversationSegment {     //A Conversation segment struct. Represents each piece in our dialogue that we will cycle between
            public string text;                 //The text of this piece.
            public int nextConversationIndex;   //If we don't have any choices, what is the next conversation index after this one?
            public bool hasChoices;             //Can the player answer with any choices from this piece?
            public string[] choices;            //List of choices the player has.
            public int[] choicePointer;         //List of which index in the conversation array this choice points to.
            public bool endsConversation;
        }
        [System.Serializable]
        public class NPCSettings //Our settings class
        {
            public ConversationSegment[] conversation;             
        }

        [HideInInspector] //Hide the settings from the NPC itself so that we don't accidentally not use a proxy
        public NPCSettings settings; //Create an instance of our settings
        ConversationUI ui; //Reference to the UI
        

        public void Start_Conversation()
        {
            GameObject.Find("Singleton").GetComponent<Singleton>().conversationUI.gameObject.SetActive(true); //Find the singleton and activate the conversation UI.
            ui = FindObjectOfType<ConversationUI>(); 
            StartCoroutine(Conversation()); //Start the conversation
        }

        IEnumerator Conversation()
        {
            bool conversationRunning = true;
            int index = 0;
            ConversationSegment[] conversation = settings.conversation;
            while (conversationRunning) //For each segment of text in the conversation
            {
                ui.SetText(conversation[index].text); //Set the text
                ui.currentChoices = conversation[index].choices.Length - 1;

                if (conversation[index].hasChoices) //If we have choices in this segment
                {
                    ui.SetChoices(conversation[index].choices); //Set the UI conversation choice texts
                    Debug.Log("" + conversation[index].choices);
                   
                }

                yield return new WaitForEndOfFrame(); //We need this or else the interact button is still pressed in the same frame as the conversation starts
                yield return StartCoroutine(InputHandler.WaitForButtonDown("Interact")); //And wait for the user to press continue

                if (conversation[index].endsConversation) //End the conversation if this segment is supposed to end it.
                {
                    conversationRunning = false; 
                }

                else {
                    if (conversation[index].hasChoices)
                    {
                        index = conversation[index].choicePointer[ui.choicePointer]; //If we made a conversation choice, go to the index that the chosen choice leads to
                    }
                    else {
                        index = conversation[index].nextConversationIndex; //Else just go on to the index that is supposed to come after this one.
                    }
                }
                ui.Cleanup(); //Cleanup UI
            }
            ui.gameObject.SetActive(false); //When done disable the UI
            
            On_Interact_Finished(); //And be done interacting
            yield break;

        }
    }
}


