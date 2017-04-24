using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
    public class PlayerInteraction : MonoBehaviour
    {
        public Interact target;     //The target of type Interact
        private Transform cam;         //Camera
        private Vector3 screenPoint;


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

                }
                else
                {
                    target = null;
                }
            }
            if (target != null && !target.interacted)
            {                                          //If we have a target
                if (Input.GetButtonDown("Interact"))
                {                                              //And we press the interact button
                    target.On_Interact();                                                           //Interact with it
                }
            }
        }
        void OnTriggerEnter (Collider coll)
        {
            if (coll.transform.gameObject.GetComponent<Interact>())
            {
                coll.transform.gameObject.GetComponent<Interact>().On_Interact();
                coll.enabled = false;
                
                
               
            }
        }
    }
}
