using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour {


    public static IEnumerator WaitForButtonDown(string button) { //This Coroutine waits for the input of a button with the argument being a string of the input button name.

        while (!Input.GetButtonDown(button)){
            yield return null;
        }
        yield return null;
        }
}
