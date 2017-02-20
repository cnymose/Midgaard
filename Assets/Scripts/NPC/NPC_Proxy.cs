using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard { // <--- Important to include namespace whenever making proxy/normal references
    public class NPC_Proxy : MonoBehaviour { 
                                             //Proxy for the NPC class. This is used to set settings of a specific NPC, rather than having to assign
                                             //each variable of the class in the inspector, and risk losing settings on prefab updates.

        public NPC.NPCSettings settings;
        public NPC target;


        void Start() {
            Set_Settings();
        }

  
        void Update() {

        }

        void Set_Settings() {
            target.settings = settings; //sets the NPCSettings class of the NPC
        }
    }
}
