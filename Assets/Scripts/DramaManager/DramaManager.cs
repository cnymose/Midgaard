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

        [System.Serializable]
        public class TimedEvents
        {
            public NPC timed_Event;
           
        }

        [System.Serializable]
        public class SpawnedEvents
        {
            public NPC spawned_Event;
        }

      

        public TimedEvents[] timedEvents;
        public SpawnedEvents[] spawnedEvents;
        public StorySegment[] storySegments;
        public List<NPC> spawn;
        

        private int currentTimedEvent = 0;
        private int currentStorySegment = 0;
        private int currentMinorEvent = 0;
        private int currentSpawnedEvent = 0;
        private float distanceTravelledSinceEvent;
        private float lastEventTimestamp;
        private float lastMainEventTimestamp;
        private float timeSinceEvent;

        public Transform player;
        
     
        void Start()
        {
            player = FindObjectOfType<PlayerMovement>().transform;            
            SubscribeToEvents();
            SubscribeMainEvents();
            SubscribeTimedEvents();
            SubscribeSpawnedEvents();
        }

        private void On_Interact_Finished(float time, Interact interact)
        {                                                                   //When we interact with a smaller object
            lastEventTimestamp = time;                                      //Set the timestamp
            interact.onInteracted -= On_Interact_Finished;                  //And unsubscribe from its interacted event.
           
           
        }

        private void On_MainEvent_Finished(float time, Interact interact) //When we interact with main events
        {                                               
            lastMainEventTimestamp = time;                                //Set timestamp
            interact.onInteracted -= On_MainEvent_Finished;               //Unsubscribe the function from interact event

            if (!storySegments[0].isTimed)
            {
                storySegments[0].isTimed = true;
                StartCoroutine(CountDown(timedEvents[0]));
            }

            if (currentStorySegment + 1 < storySegments.Length)
            {
                currentStorySegment++;                                    //If there are more story segments left, set the next current story segment.
            }
            
        }

        private void On_Spawned_Time_Events(float time, Interact interact)
        {
            interact.onInteracted -= On_Spawned_Time_Events;
            StartCoroutine(WaitForSpawn());
                
            
        }

        private void On_Timed_Event(float time, Interact interact)
        {
            interact.onInteracted -= On_Timed_Event;

            if(currentTimedEvent + 1 < timedEvents.Length)
            {
                currentTimedEvent++;
            }
           
        }


        public void SubscribeMainEvents()
        {
            for (int j = 0; j < storySegments.Length - 1; j++)
            {
                storySegments[j].mainEvent.onInteracted += On_MainEvent_Finished; // Subscribe main events to interact Event
            }
        }


        private void SubscribeToEvents()
        {                   
            for (int i = 0; i < storySegments[currentStorySegment].interacts.Length; i++)
            {               
                storySegments[currentStorySegment].interacts[i].interactObject.onInteracted += On_Interact_Finished; //Adds listeners to every minor event as to when we're done interacting with them.
            }      

        }

        private void SubscribeTimedEvents()
        {
            for(int i = 0; i < timedEvents.Length; i ++)
            {
                timedEvents[i].timed_Event.onInteracted += On_Timed_Event;
            }
        }

        private void SubscribeSpawnedEvents()
        {
            for (int i = 0; i < spawnedEvents.Length; i++)
            {
                spawnedEvents[i].spawned_Event.onInteracted += On_Spawned_Time_Events;
            }
        }

        IEnumerator CountDown(TimedEvents timedEvent)
        {

            yield return new WaitForSeconds(10);
            timedEvent.timed_Event.On_Interact();
            

            yield return null;
            
        }

        IEnumerator WaitForSpawn()
        {
            yield return new WaitForSeconds(20);
            StartCoroutine(SpawnIt());
            yield break;
        }

        IEnumerator SpawnIt()
        {
            bool cast = false;
            while (!cast)
            {
                yield return new WaitForSeconds(2);
                
                cast = player.gameObject.GetComponent<Spawn_event>().raycastStart();
                Debug.Log(cast);
                if (cast)
                {
                    FindObjectOfType<shrineNPC>().OnLoad();
                    spawn.Add(FindObjectOfType<shrineNPC>());
                    spawn[0].onInteracted += On_Interact_Finished;
                    yield break;

                }
                yield return null;
            }
            
                
        }
        
    }
}
