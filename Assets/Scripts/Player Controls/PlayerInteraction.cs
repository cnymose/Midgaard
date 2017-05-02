﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class PlayerInteraction : MonoBehaviour
    {
        public Interact target;     //The target of type Interact
        private Transform cam;         //Camera
        private Vector3 screenPoint;
        public Canvas Interact_UI;
        


        void Start()
        {
           
            cam = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit))
            { //Raycast forward
                if (hit.transform.gameObject.GetComponent<Interact>() && Vector3.Distance(transform.position, hit.transform.position) < 5)                              //If we hit an object with the "interact" component on it
                {
                    target = hit.transform.gameObject.GetComponent<Interact>();                       //Set that as out target
                    Interact_UI.gameObject.SetActive(true);
                }
                else
                {
                    target = null;
                    Interact_UI.gameObject.SetActive(false);
                }
            }
            if (target != null && !target.interacted)
            {                                          //If we have a target
               
                if (Input.GetButtonDown("Interact"))
                {                                              //And we press the interact button
                    Interact_UI.gameObject.SetActive(false);
                    target.On_Interact();                                                           //Interact with it
                }
            }
        }
        void OnTriggerEnter (Collider coll) // Interact with NPC on approach
        {
            if (coll.transform.gameObject.GetComponent<Interact>())
            {
                coll.transform.gameObject.GetComponent<Interact>().On_Interact();
                coll.enabled = false;
                
                
               
            }
        }
    }
}
