using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{

    public class DramaManager : MonoBehaviour
    {
        [System.Serializable]
        public class InteractTracker {   // Tracks if we have interacted with each "smaller" event.
            public Interact interactObject;
            public bool hasInteracted;
        }
        [System.Serializable]
        public class StorySegment   // A class to store the content of each segment of the story. A segment is considered everything between two "Required" events of the story.
        {
            public InteractTracker[] interacts;
            public Interact mainEvent;
            public float maxTimeOfSegment;
            public bool isTimed = false;            
        }


        public StorySegment[] storySegments;

        private int currentStorySegment = 0;
        private float distanceTravelledSinceEvent;
        private float lastEventTimestamp;
        private float timeSinceEvent;

        private Transform player;


        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<PlayerMovement>().transform;

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void On_Interact_Finished(float time, Interact interact) {  //When we interact with a smaller object
            lastEventTimestamp = time;                                      //Set the timestamp
            interact.onInteracted -= On_Interact_Finished;                  //And unsubscribe from its interacted event.
        }

        private void SubscribeToEvents() { //Adds listeners to every minor event as to when we're done interacting with them.
            for (int i = 0; i < storySegments[currentStorySegment].interacts.Length; i++) {
                storySegments[currentStorySegment].interacts[i].interactObject.onInteracted += On_Interact_Finished;
            }
        }

    }
}
