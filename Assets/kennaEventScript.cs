using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard {
    public class kennaEventScript : NPC {
        private NPC_Proxy[] NPCs;
        private bool proceed = true;
        private PlayerInteraction pInt;
        // Drama manager story bool, check for isTimed if interacted with main event. If false, run coroutine to start the timed event.


        public void initializeEvent()
        {
            Start_Conversation();
        }
      

        IEnumerator CountDown()
        {

            yield return new WaitForSeconds(10);
            

        }
    }
}