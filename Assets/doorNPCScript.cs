using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class doorNPCScript : NPC
    {
        private AudioSource source;
        private NPC_Proxy npcProx;
        private string[] strings = {"Go away!", "This is no inn!", "I would not open for Vidar himself!" };
       public AudioClip[] clips;

        
       public void setText()
        {
            npcProx = GameObject.Find("Door_Proxy").gameObject.GetComponent<NPC_Proxy>();
            var rnd = Random.Range(0, strings.Length);
            npcProx.settings.conversation[0].text = strings[rnd];
            npcProx.settings.conversation[0].endsConversation = true;
            npcProx.settings.clip = clips[rnd];
            npcProx.Set_Settings();
            
        }

        public void knock_door()
        {
            source = GameObject.Find("DoorKnock").gameObject.GetComponent<AudioSource>();
            source.Play();
            StartCoroutine(wait());

        }
        IEnumerator wait()
        {
            yield return new WaitForSeconds(3f);
            Start_Conversation();
        }
    }
}
