using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Midgaard
{
    public class vroklNPC : NPC
    {
        private AudioSource source;
        private NPC[] NPCs;
        private NPC_Proxy npcprox;
               
        public void knock_door()
        {
            npcprox = GameObject.Find("Vrokr_Proxy").gameObject.GetComponent<NPC_Proxy>();
            npcprox.target = this;
            npcprox.Set_Settings();
            NPCs = FindObjectsOfType<NPC>();
          /*  var manager = FindObjectOfType<DramaManager>();
            manager.storySegments[2].mainEvent = this;
            manager.spawnedEvents[0].spawned_Event = this; */
            source = GameObject.Find("DoorKnock").gameObject.GetComponent<AudioSource>();
            source.Play();
            StartCoroutine(wait());

        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(3f);
            Start_Conversation();
            foreach(NPC npc in NPCs)
            {
                if(npc.transform.name == "Vrokr" && !npc.transform.gameObject.Equals(transform.gameObject))
                {
                    npc.transform.gameObject.SetActive(false);
                }
                if(npc.transform.name == "Door")
                {
                    npc.enabled = true;
                }
            }
        }
    }
}
