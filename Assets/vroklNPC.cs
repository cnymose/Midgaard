using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Midgaard
{
    public class vroklNPC : NPC
    {
        private AudioSource source;
        
               
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
