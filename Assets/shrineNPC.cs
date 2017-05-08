﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class shrineNPC : NPC
    {
        private NPC_Proxy[] npcProxys;
      
        public void OnLoad()
        {
          
            npcProxys = FindObjectsOfType<NPC_Proxy>();

            for (int i = 0; i < npcProxys.Length; i ++)
            {
                if(npcProxys[i].name == "Shrine_Proxy")
                {

                    npcProxys[i].target = this;
                    npcProxys[i].Set_Settings();
                }
            }
        }  

    }
}