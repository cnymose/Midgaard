using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class guardSetText : NPC
    {
        public NPC_Proxy npcProx;
        private string[] strings = { "Move along...", "Find shelter, stranger...", "I would not venture out at night. Creatures lurk in the darkness!" };
        public AudioClip[] clips;


        public void setText()
        {
            var rnd = Random.Range(0, strings.Length);
            npcProx.settings.conversation[0].text = strings[rnd];
            npcProx.settings.conversation[0].endsConversation = true;
            npcProx.settings.clip = clips[rnd];
            Start_Conversation();

        }
    }
}