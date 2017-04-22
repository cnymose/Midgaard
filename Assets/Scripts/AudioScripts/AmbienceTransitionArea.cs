using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmbienceTransitions
{

    public class AmbienceTransitionArea : MonoBehaviour
    {
        public AmbienceManager ambienceTrack;

        void OnTriggerEnter(Collider coll) {

            FindObjectOfType<AmbienceManager>().source.Stop();
            FindObjectOfType<AmbienceManager>().source.clip = FindObjectOfType<AmbienceManager>().ambiences[1];
            FindObjectOfType<AmbienceManager>().source.Play();

        }
    }
}
