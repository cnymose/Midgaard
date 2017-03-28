using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Midgaard
{
    public class InteractOnEnter : MonoBehaviour
    {
        public UnityEvent OnEnterEvent;
        // Use this for initialization

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player") {
                OnEnterEvent.Invoke();
            }
        }
    }
}
