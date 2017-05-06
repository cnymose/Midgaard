using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Midgaard
{
    public abstract class Interact : MonoBehaviour
    { //This script can be placed on any object that we want the player
      //to be able to interact with. We can point to any gameobjects class/method,
      //with the UnityEvent and invoke the selected method.

        public UnityEvent method;

        public bool interacted = false;
        public bool interacting = false;
        public delegate void On_Interacted(float time, Interact interact);
        public event On_Interacted onInteracted;
        private InputHandler inputHandler;

        // Use this for initialization
        public virtual void Start()
        {
            inputHandler = FindObjectOfType<InputHandler>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void On_Interact()
        {             //When this method is called from outside this script
            
            inputHandler.SetMovementLocked(true);
            interacting = true;
            method.Invoke();                    //Call the method that we select in the inspector for this given object
        }

        public void On_Interact_Finished()
        {
            
            interacting = false;
            inputHandler.SetMovementLocked(false);
            if (!interacted)
            {
                onInteracted(Time.time, this as Interact);
                interacted = !interacted;
            }
            
        }
    }
}
