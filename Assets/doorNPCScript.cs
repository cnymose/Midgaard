using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class doorNPCScript : NPC
    {
        private AudioSource source;
        public NPC_Proxy npcProx;
        private string[] strings = {"Go away!", "This is no inn!", "I would not open for Vidar himself!" };

        
       public void setText()
        {
            var rnd = Random.Range(0, strings.Length);
            npcProx.settings.conversation[0].text = strings[rnd];
            npcProx.settings.conversation[0].endsConversation = true;
            
        }

        public void knock_door()
        {
            source = GetComponent<AudioSource>();
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
