using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {            //This class keeps references to all our "one of a kind" 
                                                    //objects that we always want to keep in the game
    public ConversationUI conversationUI;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
