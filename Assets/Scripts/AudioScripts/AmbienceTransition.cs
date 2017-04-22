using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmbienceTransitions
{

    public class AmbienceTransition : MonoBehaviour
    {

        public AmbienceManager.AmbienceSettings settings;

        void OnTriggerEnter(Collider coll)
        {
            Debug.Log("You entered");
            FindObjectOfType<AmbienceManager>().targetSettings = settings;

        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("You exited");
            FindObjectOfType<AmbienceManager>().RevertToStart();
        }
    }
}
