using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Midgaard {
    public class PlayMovie : MonoBehaviour {

        // Use this for initialization
        public string SceneName;
        public bool playing = true;
        public void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                myMovie.Play();
                aud.Play();
                playing = false;

            }
        }
        public void Launch() {
            myMovie.Play();
            aud.Play();
            playing = false;
        }

        // Update is called once per frame
        void Update() {

            if (!myMovie.isPlaying && !playing) {
                if (myMovie.name == "Intro") {
                    SceneManager.LoadScene(SceneName);
                }
                
                Debug.Log("slut");
            }
            if (SceneManager.GetActiveScene().buildIndex == 2 && !myMovie.isPlaying){

                
                FindObjectOfType<continuationScript>().ContinueEvent();
                enabled = false;
            }

        }


        public MovieTexture myMovie;
        public AudioSource aud;

        private IEnumerator Wait(float duration)
        {
            yield return new WaitForSeconds(duration);
        }

        void OnGUI() {
            if(!playing)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myMovie);

        }


    }

}
