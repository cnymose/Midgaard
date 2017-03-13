using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class NPC : Interact
    {

        [System.Serializable]
        public class NPCSettings //Our settings class
        {
            public NPCSettings(string[] conversation) //Constructor
            {
                this.conversation = conversation;
            }
            public string[] conversation; //has an array of strings for our conversation
        }

        public NPCSettings settings; //Create an instance of our settings
        ConversationUI ui; //Reference to the UI
        

        void Start()
        {

        }

    
        void Update()
        {

        }

        public void Start_Conversation()
        {
            GameObject.Find("Singleton").GetComponent<Singleton>().conversationUI.gameObject.SetActive(true); //Find the singleton and activate the conversation UI.
            ui = GameObject.Find("Singleton").GetComponent<Singleton>().conversationUI; 
            StartCoroutine(Conversation()); //Start the conversation
        }

        IEnumerator Conversation()
        {
            for (int i = 0; i < settings.conversation.Length; i++) //For each segment of text in the conversation
            {
                ui.SetText(settings.conversation[i]); //Set the text
                yield return new WaitForEndOfFrame(); //We need this or else the interact button is still pressed in the same frame as the conversation starts
                yield return StartCoroutine(InputHandler.WaitForButtonDown("Interact")); //And wait for the user to press continue
            }
            ui.gameObject.SetActive(false); //When done disable the UI
            GetComponent<Interact>().interacted = false; //And be ready to interact with the NPC again
            yield break;

        }
    }
}


